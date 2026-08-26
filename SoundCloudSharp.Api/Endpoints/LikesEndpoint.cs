using SoundCloudSharp.Api.Http;
using SoundCloudSharp.Api.utils;
using SoundCloudSharp.Api.Exceptions;

namespace SoundCloudSharp.Api.Endpoints;

/// <summary>
/// Liking Tracks & Playlists.
/// </summary>
public class LikesEndpoint(ApiConnector connector) : ApiEndpoint(connector)
{
    /// <summary>
    /// Likes a track.
    ///
    /// Corresponds to <c>POST /likes/tracks/{track_urn}</c>
    /// </summary>
    /// <param name="trackUrn">Urn of the track that will be liked</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The track associated with the <paramref name="trackUrn"/> doesn't exist</exception>
    /// <exception cref="ApiTooManyRequestsException">The request exceeds a SoundCloud API rate limit</exception>
    public async Task LikeTrackAsync(string trackUrn, CancellationToken cancellationToken = default)
    { 
        await Connector.PostAsync(SoundCloudUrls.LikeTracks(trackUrn), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Unlikes a track.
    ///
    /// Corresponds to <c>DELETE /likes/tracks/{track_urn}</c>
    /// </summary>
    /// <param name="trackUrn">Urn of the track that will be unliked</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiNotFoundException">The track associated with the <paramref name="trackUrn"/> doesn't exist</exception>
    public async Task UnlikeTrackAsync(string trackUrn, CancellationToken cancellationToken = default)
    {
        await Connector.DeleteAsync(SoundCloudUrls.LikeTracks(trackUrn), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Likes a playlist.
    ///
    /// Corresponds to <c>POST /likes/playlists/{playlist_urn}</c>
    /// </summary>
    /// <param name="playlistUrn">Urn of the playlist that will be liked</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiUnauthorizedException">The access token is missing, invalid or not authenticated</exception>
    /// <exception cref="ApiNotFoundException">The playlist associated with the <paramref name="playlistUrn"/> doesn't exist</exception>
    /// <exception cref="ApiTooManyRequestsException">The request exceeds a SoundCloud API rate limit</exception>
    public async Task LikePlaylistAsync(string playlistUrn, CancellationToken cancellationToken = default)
    {
        await Connector.PostAsync(SoundCloudUrls.LikePlaylists(playlistUrn), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Unlikes a playlist.
    ///
    /// Corresponds to <c>DELETE /likes/playlists/{playlist_urn}</c>
    /// </summary>
    /// <param name="playlistUrn">Urn of the playlist that will be unliked</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ApiBadRequestException">The request contains invalid or unsupported values</exception>
    /// <exception cref="ApiNotFoundException">The playlist associated with the <paramref name="playlistUrn"/> doesn't exist</exception>
    public async Task UnlikePlaylistAsync(string playlistUrn, CancellationToken cancellationToken = default)
    {
        await Connector.DeleteAsync(SoundCloudUrls.LikePlaylists(playlistUrn), cancellationToken).ConfigureAwait(false);
    }
}