using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class OpnsenseAuthenticator : IAuthenticator
{
    private readonly string _apiKey;
    private readonly string _apiSecret;
    private readonly string _identifier; // To uniquely identify this instance

    public OpnsenseAuthenticator(string apiKey, string apiSecret)
    {
        _apiKey = apiKey;
        _apiSecret = apiSecret;
        // A simple identifier for this authenticator instance
        _identifier = $"OPNsenseAuth:{apiKey}";
    }

    public void ApplyAuthentication(
        HttpRequestMessage request,
        string requestPath,
        string requestBody
    )
    {
        string signature = GenerateSha512Signature(_apiSecret, requestPath, requestBody);

        // Ensure headers are cleared before adding to avoid issues if HttpClient is reused
        // and previous request had different auth. SendAsync creates new req.Headers collection but better safe.
        request.Headers.Remove("X-OPNsense-API");
        request.Headers.Remove("X-OPNsense-Signature");

        request.Headers.Add("X-OPNsense-API", _apiKey);
        request.Headers.Add("X-OPNsense-Signature", signature);
    }

    public string GetIdentifier()
    {
        return _identifier;
    }

    /// <summary>
    /// Helper method to generate the SHA512 signature.
    /// Signature is SHA512(api_secret + request_path + request_body_json_string)
    /// </summary>
    private string GenerateSha512Signature(string apiSecret, string requestPath, string requestBody)
    {
        using (SHA512 sha512Hash = SHA512.Create())
        {
            string rawSignature = apiSecret + requestPath + requestBody;
            byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(rawSignature));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
