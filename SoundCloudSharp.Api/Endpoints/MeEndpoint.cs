using System.Text;
using Newtonsoft.Json.Linq;
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
    public async Task<Me> Get(CancellationToken cancellationToken = default)
    {
        return await Connector.GetAsync<Me>(SoundCloudUrls.Me(), cancellationToken);
    }
    
    public async Task<ActivityPaging> GetFeed(FeedRequest? request = null, 
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        var uri = BuildUriWithQuery(SoundCloudUrls.Feed(), query);
        return await Connector.GetAsync<ActivityPaging>(uri, cancellationToken);
    }

    public async Task<ActivityPaging> GetTrackFeed(FeedRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(request);
        var uri = BuildUriWithQuery(SoundCloudUrls.FeedTracks(), query);
        return await Connector.GetAsync<ActivityPaging>(uri, cancellationToken);
    }
    
    public async Task<Paging<Track>> GetRecentlyPlayedTracks(Enums.Access[]? access = null,
        CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(access);
        var uri = BuildUriWithQuery(SoundCloudUrls.RecentlyPlayedTracks(), query);
        return await Connector.GetAsync<Paging<Track>>(uri, cancellationToken);
    }

    public async Task<Paging<Track>> GetLikedTracks(PagedTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new PagedTracksRequest();
        var query = BuildQuery(request);
        var uri = BuildUriWithQuery(SoundCloudUrls.LikedTracks(), query);
        return await Connector.GetAsync<Paging<Track>>(uri, cancellationToken);
    }

    public async Task<Paging<Playlist>> GetLikedPlaylists(PagedRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new PagedRequest();
        var query = BuildQuery(request);
        var uri = BuildUriWithQuery(SoundCloudUrls.LikedPlaylists(), query);
        return await Connector.GetAsync<Paging<Playlist>>(uri, cancellationToken);
    }

    public async Task<Paging<FullUser?>> GetFollowings(PagedRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new PagedRequest();
        var query = BuildQuery(request);
        var uri = BuildUriWithQuery(SoundCloudUrls.Followings(), query);
        return await Connector.GetAsync<Paging<FullUser?>>(uri, cancellationToken);
    }

    public async Task<Paging<Track>> GetFollowingsTracks(PagedTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new PagedTracksRequest();
        var query = BuildQuery(request);
        var uri = BuildUriWithQuery(SoundCloudUrls.FollowingsTracks(), query);
        return await Connector.GetAsync<Paging<Track>>(uri, cancellationToken);
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

    public async Task<Paging<FullUser?>> GetFollowers(int limit, CancellationToken cancellationToken = default)
    {
        var query = BuildQuery(limit);
        var response = await Connector.GetAsync<Paging<FullUser?>>(SoundCloudUrls.Followers(), query, cancellationToken);
        return response;
    }

    public async Task<Paging<Playlist>> GetPlaylists(PagedPlaylistRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new PagedPlaylistRequest();
        var query = BuildQuery(request);
        var uri = BuildUriWithQuery(SoundCloudUrls.MePlaylists(), query);
        return await Connector.GetAsync<Paging<Playlist>>(uri, cancellationToken);
    }

    public async Task<Paging<Track>> GetTracks(PagedRequest? request = null, CancellationToken cancellationToken = default)
    {
        request ??= new PagedRequest();
        var query = BuildQuery(request);
        var uri = BuildUriWithQuery(SoundCloudUrls.MeTracks(), query);
        return await Connector.GetAsync<Paging<Track>>(uri, cancellationToken);
    }

    public async Task<Paging<Track>> GetRepostsTracks(PagedTracksRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new PagedTracksRequest();
        var query = BuildQuery(request);
        var uri = BuildUriWithQuery(SoundCloudUrls.RepostTracks(), query);
        return await Connector.GetAsync<Paging<Track>>(uri, cancellationToken);
    }

    public async Task<Paging<Playlist>> GetRepostsPlaylists(PagedRequest? request = null,
        CancellationToken cancellationToken = default)
    {
        request ??= new PagedRequest();
        var query = BuildQuery(request);
        var uri = BuildUriWithQuery(SoundCloudUrls.RepostPlaylists(), query);
        return await Connector.GetAsync<Paging<Playlist>>(uri, cancellationToken);
    }
}