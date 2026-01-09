using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json; // For JSON serialization/deserialization
using System.Threading.Tasks;

/// <summary>
/// A generic API client for various platforms, supporting pluggable authentication methods.
/// </summary>
public class APIcall : IDisposable
{
    public HttpClient _httpClient = new HttpClient();
    private string? _currentBaseUrl;
    private IAuthenticator? _currentAuthenticator;
    private bool _isConnected = false;

    private string CIDR = Constants.strEMPTY;

    /// <summary>
    /// Attempts to configure the API client for a specific platform with a given authenticator.
    /// If already configured for the exact same base URL and authenticator, it returns true without re-initializing.
    /// </summary>
    /// <param name="ipOrSystemName">The IP address or SystemName of the platform (e.g., "192.168.1.1" or "firewall.local").</param>
    /// <param name="useHttps">Set to true to use HTTPS, false for HTTP.</param>
    /// <param name="authenticator">An instance of an authenticator specific to this platform's needs.</param>
    /// <returns>True if successfully configured or already configured; false otherwise.</returns>
    public APIcall(
        string ipOrSystemName,
        int port,
        bool useHttps,
        IAuthenticator authenticator,
        bool ignoreInvalidCerts = false // <-- new parameter
    )
    {
        Logger.ShowFunction("APICall.cs", "constructor");
        // Construct the full base URL including the protocol prefix and port
        string protocol = useHttps ? Constants.strHTTPS : Constants.strHTTP;
        string newBaseUrl = $"{protocol}://{ipOrSystemName.TrimEnd('/')}";
        if (
            !(protocol == Constants.strHTTP && port == 80)
            && !(protocol == Constants.strHTTPS && port == 443)
        )
        {
            newBaseUrl += $":{port}";
        }

        // Check if already configured for the same platform (base URL) and authentication
        if (
            _isConnected
            && _currentBaseUrl == newBaseUrl
            && _currentAuthenticator != null
            && _currentAuthenticator.GetIdentifier() == authenticator.GetIdentifier()
        )
        {
            Logger.Info($"Already connected to {newBaseUrl}. Reusing existing client.");
        }

        // Dispose existing client if switching platforms or authentication types
        if (_httpClient != null)
        {
            Disconnect();
        }

        try
        {
            HttpClientHandler handler = new HttpClientHandler();
            if (ignoreInvalidCerts)
            {
                handler.ServerCertificateCustomValidationCallback = (
                    message,
                    cert,
                    chain,
                    errors
                ) => true;
                Logger.Warn("Ignoring invalid SSL certificates for this connection!");
            }
            _httpClient = new HttpClient(handler) { BaseAddress = new Uri(newBaseUrl) };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("HomelabAPIClient/1.0");

            _currentBaseUrl = newBaseUrl;
            _currentAuthenticator = authenticator;
            _isConnected = true;

            CIDR = newBaseUrl;

            Logger.Info($"Successfully connected (configured) to {newBaseUrl}.");
        }
        catch (UriFormatException ex)
        {
            Logger.Error(
                $"Error: Invalid SystemName or URL format for {ipOrSystemName}. {ex.Message}"
            );
            _isConnected = false;
        }
        catch (Exception ex)
        {
            Logger.Error($"Error configuring for platform {ipOrSystemName}: {ex.Message}");
            _isConnected = false;
        }
    }

    /// <summary>
    /// Makes a GET request to a specified API endpoint and returns the JSON response.
    /// </summary>
    /// <param name="endpointPath">The relative API endpoint path (e.g., "/api/core/system/status").</param>
    /// <returns>The JSON response as a string.</returns>
    /// <exception cref="InvalidOperationException">Thrown if not connected to a platform.</exception>
    /// <exception cref="HttpRequestException">Thrown if the API call fails.</exception>
    public async Task<string> GetJsonData(
        string endpointPath,
        List<Action<HttpRequestMessage>> headerActions
    )
    {
        Logger.ShowFunction();
        //endpointPath = CIDR + endpointPath;
        Logger.Debug($"GET request to {endpointPath}");
        string s = "";
        try
        {
            s = await SendRequestAsync(HttpMethod.Get, endpointPath, headerActions);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message);
        }

        return s;
    }

    /// <summary>
    /// Performs an action on the server via a POST request and returns the JSON response.
    /// </summary>
    /// <param name="endpointPath">The relative API endpoint path (e.g., "/api/diagnostics/service/reconfigure").</param>
    /// <param name="payload">The object to be serialized to JSON and sent as the request body.</param>
    /// <returns>The JSON response as a string.</returns>
    /// <exception cref="InvalidOperationException">Thrown if not connected to a platform.</exception>
    /// <exception cref="HttpRequestException">Thrown if the API call fails.</exception>
    public async Task<string> PerformAction(string endpointPath, object payload)
    {
        endpointPath = CIDR + endpointPath;
        string jsonBody = JsonSerializer.Serialize(payload);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
        List<Action<HttpRequestMessage>>? headerActions = new List<Action<HttpRequestMessage>>();

        return await SendRequestAsync(HttpMethod.Post, endpointPath, headerActions, content);
    }

    /// <summary>
    /// Extracts a string_value from a JSON string using a specified key.
    /// Supports nested keys using dot notation (e.g., "system.info.SystemName").
    /// </summary>
    /// <param name="json">The JSON string to parse.</param>
    /// <param name="key">The key to extract (e.g., "status", "system.info.SystemName").</param>
    /// <returns>The string_value associated with the key, or null if not found.</returns>
    public string GetValue(string json, string key)
    {
        Logger.ShowFunction();
        if (string.IsNullOrWhiteSpace(json))
        {
            return Constants.strEMPTY;
        }

        try
        {
            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                JsonElement currentElement = doc.RootElement;
                string[] keyParts = key.Split('.');

                foreach (var part in keyParts)
                {
                    if (
                        currentElement.ValueKind == JsonValueKind.Object
                        && currentElement.TryGetProperty(part, out JsonElement nextElement)
                    )
                    {
                        currentElement = nextElement;
                    }
                    else
                    {
                        return Constants.strEMPTY; // Key part not found or not an object at this level
                    }
                }

                // If we reached here, currentElement holds the desired_value
                if (currentElement.ValueKind == JsonValueKind.String)
                {
                    string? temp = currentElement.GetString();
                    if (temp != null)
                    {
                        return temp;
                    }
                    else
                    {
                        return Constants.strEMPTY;
                    }
                }
                else if (currentElement.ValueKind == JsonValueKind.Number)
                {
                    return currentElement.GetRawText(); // Return number as its raw string form
                }
                else if (
                    currentElement.ValueKind == JsonValueKind.True
                    || currentElement.ValueKind == JsonValueKind.False
                )
                {
                    return currentElement.GetBoolean().ToString(); // Convert boolean to "True" or "False"
                }
                else if (currentElement.ValueKind == JsonValueKind.Null)
                {
                    return Constants.strEMPTY; // Explicitly return null for JSON null
                }
                else
                {
                    // For arrays or objects, return their raw JSON text or a suitable indicator
                    // Or throw an exception if only primitive types are expected.
                    return currentElement.GetRawText();
                }
            }
        }
        catch (JsonException ex)
        {
            Logger.Error($"Error parsing JSON: {ex.Message}");
            return Constants.strEMPTY;
        }
        catch (Exception ex)
        {
            Logger.Error($"An unexpected error occurred in GetValue: {ex.Message}");
            return Constants.strEMPTY;
        }
    }

    /// <summary>
    /// Private helper to send any type of HTTP request.
    /// </summary>
    private async Task<string> SendRequestAsync(
        HttpMethod method,
        string endpointPath,
        List<Action<HttpRequestMessage>> headerActions,
        HttpContent? content = null
    )
    {
        Logger.ShowFunction();
        if (!_isConnected || _httpClient == null || _currentAuthenticator == null)
        {
            throw new InvalidOperationException(
                "API client is not properly configured. Call ConnectToPlatform first."
            );
        }

        string requestBody;

        if (content is StringContent stringContent)
        {
            // If content is a StringContent, read it as a string
            //TODO Globals.TICKET and Globals.TOKEN
            requestBody = await stringContent.ReadAsStringAsync();
        }
        else
        {
            // Otherwise, set to empty string constant
            requestBody = Constants.strEMPTY;
        }

        try
        {
            using (var request = new HttpRequestMessage(method, endpointPath))
            {
                if (content != null)
                {
                    request.Content = content;
                }

                // Apply authentication using the currently set authenticator
                // _currentAuthenticator.ApplyAuthentication(request, endpointPath, requestBody);

                // Apply custom header/cookie actions
                if (headerActions != null)
                {
                    foreach (var action in headerActions)
                    {
                        action(request);
                    }
                }

                // request.Headers.Add(Globals.TICKET_HEADER, Globals.TICKET);
                /*
                 if (!string.IsNullOrEmpty(Globals.TOKEN)
                 //&& (method == HttpMethod.Post || method == HttpMethod.Put)
                 )
                 {
                     // Add CSRFPreventionToken header for POST/PUT
                     request.Headers.Add(Globals.TOKEN_HEADER, Globals.TOKEN);
                 }
 */
                HttpResponseMessage response;
                try
                {
                    response = await _httpClient.SendAsync(request);
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error sending request: {ex.Message}");
                    Logger.Error(ex.Message);
                    throw; // Re-throw to allow higher-level handling
                }

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return json;
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(
                        $"API call failed for {endpointPath} ({method}). Status: {response.StatusCode}, Content: {errorContent}"
                    );
                }
            }
        }
        catch (HttpRequestException ex)
        {
            Logger.Error($"HTTP request error: {ex.Message}");
            throw; // Re-throw to allow higher-level handling
        }
        catch (Exception ex)
        {
            Logger.Error($"An unexpected error occurred in SendRequestAsync: {ex.Message}");
            throw; // Re-throw to allow higher-level handling
        }
    }

    /// <summary>
    /// Disconnects from the current platform by disposing the HttpClient.
    /// </summary>
    public void Disconnect()
    {
        Logger.ShowFunction();
        if (_httpClient != null)
        {
            _httpClient.Dispose();
            // _httpClient = null;
            _currentBaseUrl = null;
            _currentAuthenticator = null; // Clear the authenticator
            _isConnected = false;
            Logger.Info("Disconnected from platform.");
        }
    }

    /// <summary>
    /// Disposes the HttpClient when the object is no longer needed (for 'using' statement).
    /// </summary>
    public void Dispose()
    {
        Disconnect();
    }
}
