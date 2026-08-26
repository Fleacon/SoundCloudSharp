using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Response;
using SoundCloudSharp.Api.utils;
using SoundCloudSharp.Api.Exceptions;

namespace SoundCloudSharp.Api.Endpoints;

/// <summary>
/// Reposting Tracks & Playlists.
/// </summary>
public class RepostsEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    /// <summary>
    /// Returns a list of track reposts of the authenticated user.
    /// 
    /// Corresponds to <c>GET /me/reposts/tracks</c>
    /// </summary>
    /// <param name="request">Optional filters and paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of tracks reposted by the authenticated user.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    public async Task<Paging<Track>> GetRepostedTracksAsync(GetRepostedTrackRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.MeRepostTracks(), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of playlist reposts of the authenticated user.
    /// 
    /// Corresponds to <c>GET /me/reposts/playlists</c>
    /// </summary>
    /// <param name="request">Optional filters and paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of playlists reposted by the authenticated user.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    public async Task<Paging<Playlist>> GetRepostedPlaylistsAsync(GetRepostedPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.MeRepostPlaylists(), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of users track reposts.
    /// 
    /// Corresponds to <c>GET /users/{user_urn}/reposts/tracks</c>
    /// </summary>
    /// <param name="userUrn">Urn of the user which reposted tracks are returned</param>
    /// <param name="request">Optional filters and paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of tracks reposted by the user associated <paramref name="userUrn"/></returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The user associated with the <paramref name="userUrn"/> doesn't exist</exception>
    public async Task<Paging<Track>> GetUserRepostedTracksAsync(string userUrn, GetUserRepostedTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.UserRepostedTracks(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of user's playlist reposts.
    /// 
    /// Corresponds to <c>GET /users/{user_urn}/reposts/playlists</c>
    /// </summary>
    /// <param name="userUrn">Urn of the user which reposted playlists are returned</param>
    /// <param name="request">Optional paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns></returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The user associated with the <paramref name="userUrn"/> doesn't exist</exception>
    public async Task<Paging<Playlist>> GetUserRepostedPlaylistsAsync(string userUrn, GetUserRepostedPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.UserRepostedPlaylists(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Reposts a track as the authenticated user
    /// 
    /// Corresponds to <c>POST /reposts/tracks/{track_urn}</c>
    /// </summary>
    /// <param name="trackUrn">Urn of the track which will be reposted by the authenticated user</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The track associated with the <paramref name="trackUrn"/> doesn't exist</exception>
    public async Task RepostTrackAsync(string trackUrn, CancellationToken cancellationToken = default)
    { 
        await Connector.PostAsync(SoundCloudUrls.RepostTracks(trackUrn), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Reposts a playlist as the authenticated user
    /// 
    /// Corresponds to <c>POST /reposts/playlists/{playlist_urn}</c>
    /// </summary>
    /// <param name="playlistUrn">Urn of the playlist which will be reposted by the authenticated user</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The playlist associated with the <paramref name="playlistUrn"/> doesn't exist</exception>
    public async Task RepostPlaylistAsync(string playlistUrn, CancellationToken cancellationToken = default)
    { 
        await Connector.PostAsync(SoundCloudUrls.RepostPlaylists(playlistUrn), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Removes a repost on a playlist as the authenticated user
    /// 
    /// Corresponds to <c>DELETE /reposts/playlists/{playlist_urn}</c>
    /// </summary>
    /// <param name="playlistUrn"></param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The playlist associated with the <paramref name="playlistUrn"/> doesn't exist</exception>
    public async Task RemoveRepostPlaylistAsync(string playlistUrn, CancellationToken cancellationToken = default)
    {
        await Connector.DeleteAsync(SoundCloudUrls.RepostPlaylists(playlistUrn), cancellationToken).ConfigureAwait(false);
    }
}