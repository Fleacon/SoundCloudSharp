using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Exceptions;

namespace SoundCloudSharp.Api.Endpoints;

/// <summary>
/// Authentication and Authorization Endpoints.
/// </summary>
public class OAuthEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    /// <summary>
    /// Revokes OAuth access for the calling application.
    /// </summary>
    /// <remarks>Invalidates access tokens for the client application that issued the current access token. Returns 400 if disconnect is not supported for the current token.</remarks>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <exception cref="ApiBadRequestException">A token to monitor for cancellation requests.</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiInternalServerErrorException">SoundCloud encountered an internal error while processing the request</exception>
    public async Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        await Connector.PostAsync(SoundCloudUrls.Disconnect(), cancellationToken);
    }
}