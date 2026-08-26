namespace SoundCloudSharp.Api.Models.Request;

public record StartTrackPreviewPlaybackRequest
{
    /// <summary>
    /// A secret token to fetch private playlists/tracks
    /// </summary>
    [QueryParam("secret_Token")]
    public string? SecretToken { get; init; }
}