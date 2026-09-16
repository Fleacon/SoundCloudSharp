using SoundCloudSharp.Api.Http;

namespace SoundCloudSharp.Api.Authenticators;

/// <summary>
/// Implements an authenticator that applies a static, pre-existing access token 
/// to outgoing API requests against SoundCloud's endpoints.
/// </summary>
/// <remarks>
/// Unlike <see cref="OAuthTokenAuthenticator"/>, this authenticator does not handle 
/// token expiration or automatic refreshing. It simply injects the provided 
/// access token directly into the request's Authorization header.
/// </remarks>
/// <param name="accessToken">The static OAuth access token to use for authorization.</param>
public class StaticTokenAuthenticator(string accessToken) : IAuthenticator
{
    public string AccessToken { get; set; } = accessToken;
    
    public Task Apply(Request request, ApiConnector connector, CancellationToken cancellationToken = default)
    {
        request.Headers["Authorization"] = $"OAuth {AccessToken}";
        return Task.CompletedTask;
    }
}