using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record SearchTracksRequest
{
    [QueryParam("q")]
    public string? Query { get; init; }
    [QueryParam("urns")]
    public string[]? Urns { get; init; }
    [QueryParam("genres")]
    public string[]? Genres { get; init; }
    [QueryParam("tags")]
    public string[]? Tags { get; init; }
    [QueryParamRange("bpm")]
    public RangeFilter<int>? Bpm { get; init; }
    [QueryParamRange("duration")]
    public RangeFilter<int>? Duration { get; init; }
    [QueryParamRange("created_at")]
    public RangeFilter<DateTimeOffset>? CreatedAt { get; init; }
    [QueryParamRange("access")]
    public Enums.Access[]? Access { get; init; }
    public PagingOptions? Page { get; init; } = new();
}