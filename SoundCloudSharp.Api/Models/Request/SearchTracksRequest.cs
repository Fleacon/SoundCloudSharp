using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record SearchTracksRequest
{
    /// <summary>
    /// Search query
    /// </summary>
    [QueryParam("q")]
    public string? Query { get; init; }
    /// <summary>
    /// List of track urns to filter on
    /// </summary>
    [QueryParam("urns")]
    public string[]? Urns { get; init; }
    /// <summary>
    /// A list of genres
    /// </summary>
    [QueryParam("genres")]
    public string[]? Genres { get; init; }
    /// <summary>
    /// A list of tags
    /// </summary>
    [QueryParam("tags")]
    public string[]? Tags { get; init; }
    /// <summary>
    /// Return tracks with a specified bpm
    /// </summary>
    [QueryParamRange("bpm")]
    public RangeFilter<int>? Bpm { get; init; }
    /// <summary>
    /// Return tracks within a specified duration range
    /// </summary>
    [QueryParamRange("duration")]
    public RangeFilter<int>? Duration { get; init; }
    /// <summary>
    /// Return tracks created within the specified dates
    /// </summary>
    [QueryParamRange("created_at")]
    public RangeFilter<DateTimeOffset>? CreatedAt { get; init; }
    /// <summary>
    /// Filters content by level of access the user (logged in or anonymous) has to the track. The result list will include only tracks with the specified access. Include all options if you'd like to see all possible tracks.
    /// </summary>
    /// <remarks>If <see langword="null"/> or omitted, the request uses SoundCloud's default values:
    /// <see cref="Enums.Access.Playable"/>
    /// <see cref="Enums.Access.Preview"/>
    /// </remarks>
    [QueryParamRange("access")]
    public Enums.Access[]? Access { get; init; }
    /// <summary>
    /// Gets the pagination options to apply to the request.
    /// </summary>
    public PagingOptions? Page { get; init; } = new();
}