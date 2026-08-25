namespace SoundCloudSharp.Api.Models.Request;

public record GetTrackStreamsRequest
{
    [QueryParam("secret_token")]
    public string SecretToken { get; init; }
}