using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.Models.Common;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Request.Paging;
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
    public async Task<Me> Get(CancellationToken cancellationToken = default)
    {
        return await Connector.GetAsync<Me>(SoundCloudUrls.Me(), cancellationToken);
    }
    
    public async Task<ActivityPaging> GetFeed(FeedRequest? request = null, 
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<ActivityPaging>(SoundCloudUrls.Feed(), query, cancellationToken);
    }

    public async Task<ActivityPaging> GetTrackFeed(FeedRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<ActivityPaging>(SoundCloudUrls.FeedTracks(), query, cancellationToken);
    }
    
    public async Task<Paging<Track>> GetRecentlyPlayedTracks(Enums.Access[]? access = null,
        CancellationToken cancellationToken = default)
    {
        access ??= [Enums.Access.Playable, Enums.Access.Preview, Enums.Access.Blocked];
        var query = QueryStringBuilder.BuildScalar("access", access);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.RecentlyPlayedTracks(), query, cancellationToken);
    }

    public async Task<Paging<Track>> GetLikedTracks(GetMeLikedTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.LikedTracks(), query, cancellationToken);
    }

    public async Task<Paging<Playlist>> GetLikedPlaylists(GetMeLikedPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.LikedPlaylists(), query, cancellationToken);
    }

    public async Task<Paging<FullUser?>> GetFollowings(GetMeFollowingsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.Followings(), query, cancellationToken);
    }

    public async Task<Paging<Track>> GetFollowingsTracks(GetMeFollowingsTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.FollowingsTracks(), query, cancellationToken);
    }

    public async Task<FollowResult> FollowUser(string userUrn, CancellationToken cancellationToken = default)
    {
        return await Connector.PutAsync<FollowResult>(SoundCloudUrls.Follow(userUrn), cancellationToken);
    }
    
    public async Task<bool> UnfollowUser(string userUrn, CancellationToken cancellationToken = default)
    {
        var response  = await Connector.DeleteAsync(SoundCloudUrls.Follow(userUrn), cancellationToken);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    public async Task<Paging<FullUser?>> GetFollowers(int? limit = null, CancellationToken cancellationToken = default)
    {
        var query = QueryStringBuilder.BuildScalar("limit", limit);
        var response = await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.Followers(), query, cancellationToken);
        return response;
    }

    public async Task<Paging<Playlist>> GetPlaylists(GetMePlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.MePlaylists(), query, cancellationToken);
    }

    public async Task<Paging<Track>> GetTracks(GetMeTracksRequest? request = null, CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.MeTracks(), query, cancellationToken);
    }

    public async Task<Paging<Track>> GetRepostsTracks(GetMeRepostsTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Track>>(SoundCloudUrls.MeRepostTracks(), query, cancellationToken);
    }

    public async Task<Paging<Playlist>> GetRepostsPlaylists(GetMeRepostsPlaylistsRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new ();
        var query = BuildQuery(request);
        return await Connector.GetAsync<Paging<Playlist>>(SoundCloudUrls.MeRepostPlaylists(), query, cancellationToken);
    }
}