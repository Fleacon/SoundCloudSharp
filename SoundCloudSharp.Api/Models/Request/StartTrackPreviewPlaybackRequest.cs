namespace SoundCloudSharp.Api.Models.Request;

public record StartTrackPreviewPlaybackRequest
{
    [QueryParam("secret_Token")]
    public string? SecretToken { get; init; }
}