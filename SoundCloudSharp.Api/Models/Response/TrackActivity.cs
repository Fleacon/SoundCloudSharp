namespace SoundCloudSharp.Api.Models.Response;

public record TrackActivity : Activity
{
    /// <summary>
    /// Soundcloud Track object.
    /// </summary>
    public Track Origin { get; init; }
}