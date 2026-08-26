using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Response;
using SoundCloudSharp.Api.Exceptions;

namespace SoundCloudSharp.Api.Endpoints;

/// <summary>
/// Search Endpoints.
/// </summary>
/// <remarks>Supports access tokens from both authorization_code and client_credentials flows.</remarks>
public class SearchEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    /// <summary>
    /// Performs a track search based on a query.
    /// 
    /// Corresponds to <c>GET /tracks</c>
    /// </summary>
    /// <param name="request">The search criteria, including the query, filters, and pagination options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of tracks returned by the query</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported search parameters</exception>
    /// <exception cref="ApiInternalServerErrorException">SoundCloud encountered an internal error while processing the request</exception>
    public async Task<Paging<Track>> SearchTracksAsync(SearchTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.Tracks(), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Performs a playlist search based on a query.
    /// 
    /// Corresponds to <c>GET /playlists</c>
    /// </summary>
    /// <param name="request">The search criteria, including the query, filters, and pagination options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of playlists returned by the query</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported search parameters</exception>
    public async Task<Paging<Playlist>> SearchPlaylistsAsync(SearchPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.Playlists(), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Performs a user search based on a query.
    /// 
    /// Corresponds to <c>GET /users</c>
    /// </summary>
    /// <param name="request">The search criteria, including the query, filters, and pagination options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of users returned by the query</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported search parameters</exception>
    public async Task<Paging<FullUser>> SearchUsersAsync(SearchUsersRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<FullUser>>(SoundCloudUrls.Users(), query, cancellationToken).ConfigureAwait(false);
    }
}