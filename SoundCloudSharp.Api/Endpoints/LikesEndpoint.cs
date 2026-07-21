using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Endpoints;

public class LikesEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task<bool> LikeTrack(string trackUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.PostAsync(SoundCloudUrls.LikeTracks(trackUrn), cancellationToken);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    public async Task<bool> UnlikeTrack(string trackUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.DeleteAsync(SoundCloudUrls.LikeTracks(trackUrn), cancellationToken);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    public async Task<bool> LikePlaylist(string playlistUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.PostAsync(SoundCloudUrls.LikePlaylists(playlistUrn), cancellationToken);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    public async Task<bool> UnlikePlaylist(string playlistUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.DeleteAsync(SoundCloudUrls.LikePlaylists(playlistUrn), cancellationToken);
        return HttpUtil.StatusCodeIsSuccess(response);
    }
}