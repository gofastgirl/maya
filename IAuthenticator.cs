using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// Defines the contract for an API authenticator.
/// Each platform with a different authentication method will have its own implementation.
/// </summary>
public interface IAuthenticator
{
    /// <summary>
    /// Applies the necessary authentication headers or modifies the request body for an HTTP request.
    /// </summary>
    /// <param name="request">The HttpRequestMessage to modify.</param>
    /// <param name="requestPath">The relative path of the request (e.g., "/api/status"), used for signatures.</param>
    /// <param name="requestBody">The raw JSON request body string (empty for GET/DELETE), used for signatures.</param>
    void ApplyAuthentication(HttpRequestMessage request, string requestPath, string requestBody);

    /// <summary>
    /// Gets a unique identifier for this authenticator instance (useful for comparing in ConnectToPlatform).
    /// </summary>
    string GetIdentifier();
}
