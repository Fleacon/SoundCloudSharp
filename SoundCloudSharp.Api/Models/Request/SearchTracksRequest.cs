using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record SearchTracksRequest
{
    public string? Query { get; init; }
    public string[]? Urns { get; init; }
    public string[]? Genres { get; init; }
    public string[]? Tags { get; init; }
    public RangeFilter<int>? Bpm { get; init; }
    public RangeFilter<int>? Duration { get; init; }
    public RangeFilter<DateTimeOffset>? CreatedAt { get; init; }
    public Enums.Access[]? Access { get; init; }
    public PagedRequest? Page { get; init; } = new();
}