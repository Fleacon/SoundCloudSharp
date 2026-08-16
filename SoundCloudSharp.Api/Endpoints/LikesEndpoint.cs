using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.utils;

namespace SoundCloudSharp.Api.Endpoints;

public class LikesEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    public async Task<bool> LikeTrackAsync(string trackUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.PostAsync(SoundCloudUrls.LikeTracks(trackUrn), cancellationToken).ConfigureAwait(false);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    public async Task<bool> UnlikeTrackAsync(string trackUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.DeleteAsync(SoundCloudUrls.LikeTracks(trackUrn), cancellationToken).ConfigureAwait(false);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    public async Task<bool> LikePlaylistAsync(string playlistUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.PostAsync(SoundCloudUrls.LikePlaylists(playlistUrn), cancellationToken).ConfigureAwait(false);
        return HttpUtil.StatusCodeIsSuccess(response);
    }

    public async Task<bool> UnlikePlaylistAsync(string playlistUrn, CancellationToken cancellationToken = default)
    {
        var response = await Connector.DeleteAsync(SoundCloudUrls.LikePlaylists(playlistUrn), cancellationToken).ConfigureAwait(false);
        return HttpUtil.StatusCodeIsSuccess(response);
    }
}