using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class ProxmoxAuthenticator : IAuthenticator
{
    private readonly string _username;
    private readonly string _password;
    private readonly string _identifier;

    public ProxmoxAuthenticator(string username, string password)
    {
        _username = username;
        _password = password;
        _identifier = $"BasicAuth:{username}";
    }

    public void ApplyAuthentication(
        HttpRequestMessage request,
        string requestPath,
        string requestBody
    )
    {
        string authString = $"{_username}:{_password}";
        string base64AuthString = Convert.ToBase64String(Encoding.ASCII.GetBytes(authString));

        request.Headers.Remove("Authorization"); // Clear previous if any
        request.Headers.Add("Authorization", $"Basic {base64AuthString}");
    }

    public string GetIdentifier()
    {
        return _identifier;
    }
}
