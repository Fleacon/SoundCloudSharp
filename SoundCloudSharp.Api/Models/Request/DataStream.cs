namespace SoundCloudSharp.Api.Models.Request;

public record DataStream
{
    public required Stream Data { get; init; }
    public required string FileName { get; init; }
}