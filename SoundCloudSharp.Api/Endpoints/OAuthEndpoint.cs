using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Auth;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Endpoints;

public class OAuthEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task<OAuthToken> RequestToken(AuthorizationCodeTokenRequest request, CancellationToken cancellationToken = default)
    {
        var content = new Dictionary<string, string>
        {
            ["grant_type"] = "authorization_code",
            ["client_id"] = request.ClientSecrets.ClientId,
            ["client_secret"] = request.ClientSecrets.ClientSecret,
            ["redirect_uri"] = request.AuthorizationUri.AbsoluteUri,
            ["code_verifier"] = request.CodeVerifier,
            ["code"] = request.Code
        };
        var form = new FormUrlEncodedContent(content);
        return await Connector.AuthPostAsync<OAuthToken>(SoundCloudUrls.OAuthTokenUri, form, cancellationToken: cancellationToken);
    }

    public async Task<OAuthToken> RequestToken(ClientCredentialsTokenRequest request,
        CancellationToken cancellationToken = default)
    {
        var credentials = $"{request.ClientSecrets.ClientId}:{request.ClientSecrets.ClientSecret}";
        var credBase64 = Base64Util.Encode(credentials);
        var headers = new Dictionary<string, string>
        {
            ["Authorization"] = $"Basic {credBase64}"
        };
        
        var content = new Dictionary<string, string>
        {
            ["grant_type"] = "client_credentials"
        };
        var form = new FormUrlEncodedContent(content);
        
        return await Connector.AuthPostAsync<OAuthToken>(SoundCloudUrls.OAuthTokenUri, form, headers: headers, cancellationToken: cancellationToken);
    }
}