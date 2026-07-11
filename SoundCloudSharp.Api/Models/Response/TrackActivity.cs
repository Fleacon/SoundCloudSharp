namespace SoundCloudSharp.Api.Models.Response;

public record TrackActivity : Activity
{
    public required Track Origin { get; init; }
}