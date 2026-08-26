using SoundCloudSharp.Api.Http;

namespace SoundCloudSharp.Api.Endpoints;

public class DefaultEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    /// <summary>
    /// Invalidates session associated With current token
    /// </summary>
    /// <param name="accessToken">Access token that will be invalidated</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task SignOutAsync(string accessToken, CancellationToken cancellationToken = default)
    {
        var body = new { access_token = accessToken };
        await Connector.PostAsync<object>(SoundCloudUrls.SignOut(), body, baseUri: SoundCloudUrls.SecureUri, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}