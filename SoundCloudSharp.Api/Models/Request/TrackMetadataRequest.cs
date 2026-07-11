namespace SoundCloudSharp.Api.Models.Request;

public record TrackMetadataRequest
{
    public TrackRequest Track { get; init; }
}