using System.Net;
using Newtonsoft.Json;
using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Common;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Response;
using SoundCloudSharp.Api.Exceptions;

namespace SoundCloudSharp.Api.Endpoints;


/// <summary>
/// Own User Endpoints.
/// </summary>
/// <remarks>
/// Requires an access token obtained via the authorization_code flow (resource owner required).
/// </remarks>
public class MeEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    /// <summary>
    /// Returns the authenticated user's information.
    /// 
    /// Corresponds to <c>GET /me</c>
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the
    /// authenticated user's information.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    public async Task<Me> GetAsync(CancellationToken cancellationToken = default)
    {
        return await Connector.GetAsync<Me>(SoundCloudUrls.Me(), cancellationToken).ConfigureAwait(false);
    }
    
    /// <summary>
    /// Returns the authenticated user's feed.
    /// 
    /// Corresponds to <c>GET /me/feed</c>
    /// </summary>
    /// <param name="request">Optional filters for the feed. If <see langword="null"/> or omitted, SoundCloud's default values are used.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the
    /// authenticated user's feed.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    public async Task<ActivityPaging> GetFeedAsync(FeedRequest? request = null, 
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<ActivityPaging>(SoundCloudUrls.Feed(), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the authenticated user's recent track related feed.
    /// 
    /// Corresponds to '<c>GET /me/feed/tracks</c>'
    /// </summary>
    /// <param name="request">Optional filters for the feed. If <see langword="null"/> or omitted, SoundCloud's default values are used.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the
    /// authenticated user's track related feed.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    public async Task<ActivityPaging> GetTrackFeedAsync(FeedRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<ActivityPaging>(SoundCloudUrls.FeedTracks(), query, cancellationToken).ConfigureAwait(false);
    }
    
    /// <summary>
    /// Returns the authenticated users last 25 recently played tracks.
    /// 
    /// Corresponds to <c>GET /me/recently-played/tracks</c>
    /// </summary>
    /// <remarks>Returns up to 25 full track objects in reverse chronological order. Duplicate tracks are omitted, keeping only the most recent play. Tracks that are not visible to the caller are omitted. This endpoint does not support pagination or a limit query parameter.</remarks>
    /// <param name="request">Optional filters</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the
    /// authenticated user's recently played tracks.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    public async Task<Paging<Track>> GetRecentlyPlayedTracksAsync(GetMeRecentlyPlayedTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.RecentlyPlayedTracks(), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of favorited or liked tracks of the authenticated user.
    /// 
    /// Corresponds to <c>GET /me/likes/tracks</c>
    /// </summary>
    /// <param name="request">Optional filters and paging options. If <see langword="null"/> or omitted, SoundCloud's default values are used.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the
    /// authenticated user's favorited or liked tracks.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    public async Task<Paging<Track>> GetLikedTracksAsync(GetMeLikedTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.LikedTracks(), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of favorited or liked playlists of the authenticated user.
    /// 
    /// Corresponds to <c>GET /me/likes/playlists</c>
    /// </summary>
    /// <param name="request">Optional paging options. If <see langword="null"/> or omitted, SoundCloud's default values are used.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the
    /// authenticated user's favorited or liked playlists.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    public async Task<Paging<Playlist>> GetLikedPlaylistsAsync(GetMeLikedPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.LikedPlaylists(), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of users who are followed by the authenticated user.
    /// 
    /// Corresponds to <c>GET /me/followings</c>
    /// </summary>
    /// <param name="request">Optional paging options. If <see langword="null"/> or omitted, SoundCloud's default values are used.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the
    /// authenticated user's list of followed users.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    public async Task<Paging<FullUser?>> GetFollowingsAsync(GetMeFollowingsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.Followings(), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of recent tracks from users followed by the authenticated user.
    /// 
    /// Corresponds to <c>GET /me/followings/tracks</c>
    /// </summary>
    /// <param name="request">Optional filters and paging options. If <see langword="null"/> or omitted, SoundCloud's default values are used.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of recent tracks of users followed by the authenticated user</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    public async Task<Paging<Track>> GetFollowingsTracksAsync(GetMeFollowingsTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.FollowingsTracks(), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Follows a user
    /// 
    /// Corresponds to <c>PUT /me/followings/{user_urn}</c>
    /// </summary>
    /// <remarks>Fails with 422(Unprocessable Entity) when the user cannot be followed, for example when the authenticated user has reached the maximum number of followings. The response message states the reason.</remarks>
    /// <param name="userUrn">Urn of the user which will be followed</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result's <see cref="FollowResult.WasAlreadyFollowing"/> property is <see langword="true"/> if the authenticated user was already following the specified user; otherwise, it is <see langword="false"/> and <see cref="FollowResult.User"/> contains the followed user's profile.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    /// <exception cref="ApiNotFoundException">The user associated with the <paramref name="userUrn"/> doesn't exist</exception>
    /// <exception cref="ApiUnprocessableEntityException">The user could not be followed. The response message states the reason.</exception>
    public async Task<FollowResult> FollowUserAsync(string userUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.PutAsync(SoundCloudUrls.Follow(userUrn), cancellationToken).ConfigureAwait(false);

        if (response.StatusCode != HttpStatusCode.Created)
            return new FollowResult { WasAlreadyFollowing = true, User = null };
        
        var user = JsonConvert.DeserializeObject<FullUser>(response.Body as string ?? "");
        return new FollowResult { WasAlreadyFollowing = false, User =  user };
    }

    /// <summary>
    /// Deletes a user Who is followed by the authenticated user.
    /// 
    /// Corresponds to <c>DELETE /me/followings/{user_urn}</c>
    /// </summary>
    /// <param name="userUrn">Urn of the user which will be unfollowed</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    /// <exception cref="ApiNotFoundException">The user associated with the Urn doesn't exist</exception>
    /// <exception cref="ApiUnprocessableEntityException">The user could not be unfollowed. The response message states the reason.</exception>
    public async Task UnfollowUserAsync(string userUrn, CancellationToken cancellationToken = default)
    {
        await Connector.DeleteAsync(SoundCloudUrls.Follow(userUrn), cancellationToken).ConfigureAwait(false); 
    }

    /// <summary>
    /// Returns a list of users who are following the authenticated user.
    /// 
    /// Corresponds to '<c>GET /me/followers</c>'
    /// </summary>
    /// <param name="request">Optional paging options.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of users following the authenticated user</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    public async Task<Paging<FullUser?>> GetFollowersAsync(GetMeFollowersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        var response = await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.Followers(), query, cancellationToken).ConfigureAwait(false);
        return response;
    }

    /// <summary>
    /// Returns user's playlists (sets).
    /// 
    /// Corresponds to '<c>GET /me/playlists</c>'
    /// </summary>
    /// <remarks>Returns playlist info, playlist tracks and tracks owner info.</remarks>
    /// <param name="request">Optional filters and paging options. If <see langword="null"/> or omitted, SoundCloud's default values are used.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of the authenticated users playlists</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    /// <exception cref="ApiNotFoundException">The authenticated user does not have playlists.</exception>
    public async Task<Paging<Playlist>> GetPlaylistsAsync(GetMePlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.MePlaylists(), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of user's tracks.
    /// 
    /// Corresponds to '<c>GET /me/tracks</c>'
    /// </summary>
    /// <param name="request">Optional filters, sorting and paging options. If <see langword="null"/> or omitted, SoundCloud's default values are used.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of the authenticated users tracks</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    /// <exception cref="ApiNotFoundException">The authenticated user does not have tracks uploaded.</exception>
    public async Task<Paging<Track>> GetTracksAsync(GetMeTracksRequest? request = null, CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.MeTracks(), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of track reposts of the authenticated user.
    /// 
    /// Corresponds to '<c>GET /me/reposts/tracks</c>'
    /// </summary>
    /// <param name="request">Optional filters and paging options. If <see langword="null"/> or omitted, SoundCloud's default values are used.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of tracks reposted by the authenticated user.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    public async Task<Paging<Track>> GetRepostsTracksAsync(GetMeRepostsTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.MeRepostTracks(), query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns a list of playlist reposts of the authenticated user.
    /// 
    /// Corresponds to '<c>GET /me/reposts/playlists</c>'
    /// </summary>
    /// <param name="request">Optional paging options. If <see langword="null"/> or omitted, SoundCloud's default values are used.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of playlists reposted by the authenticated user.</returns>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid, or was not obtained via authorization code flow.</exception>
    public async Task<Paging<Playlist>> GetRepostsPlaylistsAsync(GetMeRepostsPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.MeRepostPlaylists(), query, cancellationToken).ConfigureAwait(false);
    }
}