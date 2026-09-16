using SoundCloudSharp.Api.Exceptions;
using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Endpoints;

/// <summary>
/// System Playlists Endpoints (e.g. track stations, artist stations).
/// </summary>
public class SystemPlaylistsEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    /// <summary>
    /// Returns a system playlist.
    /// </summary>
    /// <param name="id">System playlist URN or identifier. Accepts a full URN (e.g. soundcloud:system-playlists:track-stations:2287580618) or the identifier portion (e.g. track-stations:2287580618).</param>
    /// <param name="request">Optional filters</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a system playlist associated with the specified <paramref name="id"/></returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported search parameters</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The system playlist associated with the <paramref name="id"/> does not exist</exception>
    public async Task<SystemPlaylist> GetSystemPlaylistsAsync(string id, GetSystemPlaylistsRequest request,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<SystemPlaylist>(SoundCloudUrls.SystemPlaylists(id), query, cancellationToken).ConfigureAwait(false);
    }
}