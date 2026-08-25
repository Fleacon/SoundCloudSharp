namespace SoundCloudSharp.Api.Models.Request;

public record GetTrackRequest
{
    [QueryParam("secret_token")]
    public string? SecretToken { get; init; }
}