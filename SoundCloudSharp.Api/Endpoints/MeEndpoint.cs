using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Common;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Response;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Endpoints;

public class MeEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    /// <summary>
    /// Returns the authenticated user's information.
    /// 
    /// Corresponds to '<c>GET /me</c>'
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Me> GetAsync(CancellationToken cancellationToken = default)
    {
        return await Connector.GetAsync<Me>(SoundCloudUrls.Me(), cancellationToken).ConfigureAwait(false);
    }
    
    public async Task<ActivityPaging> GetFeedAsync(FeedRequest? request = null, 
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<ActivityPaging>(SoundCloudUrls.Feed(), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<ActivityPaging> GetTrackFeedAsync(FeedRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<ActivityPaging>(SoundCloudUrls.FeedTracks(), query, cancellationToken).ConfigureAwait(false);
    }
    
    public async Task<Paging<Track>> GetRecentlyPlayedTracksAsync(Enums.Access[]? access = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(access, "access");
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.RecentlyPlayedTracks(), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Track>> GetLikedTracksAsync(GetMeLikedTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.LikedTracks(), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Playlist>> GetLikedPlaylistsAsync(GetMeLikedPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.LikedPlaylists(), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<FullUser?>> GetFollowingsAsync(GetMeFollowingsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.Followings(), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Track>> GetFollowingsTracksAsync(GetMeFollowingsTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.FollowingsTracks(), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<FollowResult> FollowUserAsync(string userUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.PutAsync(SoundCloudUrls.Follow(userUrn), cancellationToken).ConfigureAwait(false);

        if (response.StatusCode != HttpStatusCode.Created)
            return new FollowResult { WasAlreadyFollowing = true, User = null };
        
        var user = JsonConvert.DeserializeObject<FullUser>(response.Body as string ?? "");
        return new FollowResult { WasAlreadyFollowing = false, User =  user };

    }
    public async Task UnfollowUserAsync(string userUrn, CancellationToken cancellationToken = default)
    {
        await Connector.DeleteAsync(SoundCloudUrls.Follow(userUrn), cancellationToken).ConfigureAwait(false); 
    }

    public async Task<Paging<FullUser?>> GetFollowersAsync(int? limit = null, CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(limit, "limit");
        var response = await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.Followers(), query, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<Paging<Playlist>> GetPlaylistsAsync(GetMePlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.MePlaylists(), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Track>> GetTracksAsync(GetMeTracksRequest? request = null, CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.MeTracks(), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Track>> GetRepostsTracksAsync(GetMeRepostsTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.MeRepostTracks(), query, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Playlist>> GetRepostsPlaylistsAsync(GetMeRepostsPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.MeRepostPlaylists(), query, cancellationToken).ConfigureAwait(false);
    }
}