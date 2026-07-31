using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Response;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Authenticators;

public class ClientCredentialsAuthenticator(string clientId, string clientSecret, OAuthToken token) : IAuthenticator
{
    public string ClientId { get; init; } = clientId;
    public string ClientSecret { get; init; } = clientSecret;
    public OAuthToken CurrentToken { get; private set; } = token;
    
    public async Task Apply(Request request, ApiConnector connector, CancellationToken cancellationToken = default)
    {
        if (CurrentToken.IsExpired)
        {
            var credentials = $"{ClientId}:{ClientSecret}";
            var credBase64 = Base64Util.Encode(credentials);
            var headers = new Dictionary<string, string>
            {
                ["Authorization"] = $"Basic Base64({credBase64})"
            };
        
            var content = new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials"
            };
            var form = new FormUrlEncodedContent(content);
        
            CurrentToken = await connector.AuthPostAsync<OAuthToken>(SoundCloudUrls.OAuthTokenUri, form, headers: headers, cancellationToken: cancellationToken);
        }
        
        request.Headers["Authorization"] = $"OAuth {CurrentToken.AccessToken}";
    }
}