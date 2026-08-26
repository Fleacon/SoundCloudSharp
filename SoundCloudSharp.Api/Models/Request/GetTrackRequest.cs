namespace SoundCloudSharp.Api.Models.Request;

public record GetTrackRequest
{
    /// <summary>
    /// A secret token to fetch private playlists/tracks
    /// </summary>
    [QueryParam("secret_token")]
    public string? SecretToken { get; init; }
}