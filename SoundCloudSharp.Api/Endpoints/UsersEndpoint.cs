using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Response;
using SoundCloudSharp.Api.Exceptions;

namespace SoundCloudSharp.Api.Endpoints;

/// <summary>
/// SoundCloud Users Endpoints.
/// </summary>
public class UsersEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    /// <summary>
    /// Returns a User.
    ///
    /// Corresponds to <c>GET /users/{user_urn}</c>
    /// </summary>
    /// <param name="userUrn">Urn of the user that will be returned</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user associated with the <paramref name="userUrn"/></returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The user associated with the <paramref name="userUrn"/> does not exist</exception>
    public async Task<FullUser> GetUserAsync(string userUrn, CancellationToken cancellationToken = default)
    {
        return await Connector.GetAsync<FullUser>(SoundCloudUrls.User(userUrn), cancellationToken).ConfigureAwait(false); 
    }

    /// <summary>
    /// Returns related artist recommendations for a user on SoundCloud.
    ///
    /// Corresponds to <c>GET /users/{user_urn}/related</c>
    /// </summary>
    /// <param name="userUrn">Urn of the user to get the recommended artists</param>
    /// <param name="request">Optional paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of artists recommended for the user associated with the <paramref name="userUrn"/></returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The user associated with the <paramref name="userUrn"/> does not exist</exception>
    public async Task<Paging<FullUser?>> GetRelatedArtistsAsync(string userUrn,
        GetUserRelatedArtistsRequest? request = null, CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.UserRelated(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of user's followers.
    ///
    /// Corresponds to <c>GET /users/{user_urn}/followers</c>
    /// </summary>
    /// <param name="userUrn">Urn of the user which followers will be returned</param>
    /// <param name="request">Optional paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of users following the user associated with the <paramref name="userUrn"/></returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The user associated with the <paramref name="userUrn"/> does not exist</exception>
    public async Task<Paging<FullUser?>> GetFollowersAsync(string userUrn, GetUserFollowersRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.UserFollowers(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of user's followings.
    ///
    /// Corresponds to <c>GET /users/{user_urn}/followings</c>
    /// </summary>
    /// <param name="userUrn">Urn of the user which followings will be returned</param>
    /// <param name="request">Optional paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of users that the user associated <paramref name="userUrn"/> is following</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    public async Task<Paging<FullUser?>> GetFollowingsAsync(string userUrn, GetUserFollowingsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.UserFollowings(userUrn), query, cancellationToken).ConfigureAwait(false);
    }
    
    /// <summary>
    /// Returns a list of user's playlists.
    ///
    /// Corresponds to <c>GET /users/{user_urn}/playlists</c>
    /// </summary>
    /// <param name="userUrn">Urn of the user which playlists will be returned</param>
    /// <param name="request">Optional filters and paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of playlist by the user associated with the <paramref name="userUrn"/></returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    public async Task<Paging<Playlist>> GetPlaylistsAsync(string userUrn, GetUserPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.UserPlaylists(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of user's tracks.
    ///
    /// Corresponds to <c>GET /users/{user_urn}/tracks</c>
    /// </summary>
    /// <param name="userUrn">Urn of the user which tracks will be returned</param>
    /// <param name="request">Optional filters and paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of tracks by the user associated with the <paramref name="userUrn"/></returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    public async Task<Paging<Track>> GetTracksAsync(string userUrn, GetUserTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.UserTracks(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns list of user•s links added to their profile (website, facebook, instagram).
    ///
    /// Corresponds to <c>GET /users/{user_urn}/web-profiles</c>
    /// </summary>
    /// <param name="userUrn">Urn of the user which web profiles will be returned</param>
    /// <param name="request">Optional paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of web profiles by the user associated with the <paramref name="userUrn"/></returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    public async Task<WebProfiles> GetWebProfileAsync(string userUrn, GetUserWebProfileRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<WebProfiles>(SoundCloudUrls.UserWebProfiles(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of user's liked tracks.
    ///
    /// Corresponds to <c>GET /users/{user_urn}/likes/tracks</c>
    /// </summary>
    /// <param name="userUrn">Urn of the user which liked tracks will be returned</param>
    /// <param name="request">Optional filters and paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of liked tracks by the user associated with the <paramref name="userUrn"/></returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The user associated with the <paramref name="userUrn"/> does not exist</exception>
    public async Task<Paging<Track>> GetLikedTracksAsync(string userUrn, GetLikedUserTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.UserLikedTracks(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of user's liked playlists.
    ///
    /// Corresponds to <c>GET /users/{user_urn}/likes/playlists</c>
    /// </summary>
    /// <param name="userUrn">Urn of the user which liked playlists will be returned</param>
    /// <param name="request">Optional filters and paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of liked playlists by the user associated with the <paramref name="userUrn"/></returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The user associated with the <paramref name="userUrn"/> does not exist</exception>
    public async Task<Paging<Playlist>> GetLikedPlaylistsAsync(string userUrn, GetLikedUserPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.UserLikedPlaylists(userUrn), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of user's track reposts.
    ///
    /// Corresponds to <c>GET /users/{user_urn}/reposts/tracks</c>
    /// </summary>
    /// <param name="userUrn">Urn of the user which reposted tracks will be returned</param>
    /// <param name="request">Optional filters and paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of reposted tracks by the user associated with the <paramref name="userUrn"/></returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The user associated with the <paramref name="userUrn"/> does not exist</exception>
    public async Task<Paging<Track>> GetRepostTracksAsync(string userUrn, GetUserRepostsTracksRequest? request = null,
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
    /// <param name="userUrn">Urn of te user which reposted playlists will be returned</param>
    /// <param name="request">Optional filters and paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of playlists reposted by the user associated with the <paramref name="userUrn"/></returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The user associated with the <paramref name="userUrn"/> does not exist</exception>
    public async Task<Paging<Playlist>> GetRepostPlaylistsAsync(string userUrn, GetUserPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.UserRepostedPlaylists(userUrn), query, cancellationToken).ConfigureAwait(false);
    }
}