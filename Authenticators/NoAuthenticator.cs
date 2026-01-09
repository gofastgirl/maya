using System.Net.Http;

public class NoAuthenticator : IAuthenticator
{
    public void ApplyAuthentication(
        HttpRequestMessage request,
        string requestPath,
        string requestBody
    )
    {
        // No authentication needed, do nothing.
    }

    public string GetIdentifier()
    {
        return "NoAuth";
    }
}
