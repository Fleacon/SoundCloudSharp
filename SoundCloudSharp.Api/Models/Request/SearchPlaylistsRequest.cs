using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record SearchPlaylistsRequest
{
    /// <summary>
    /// Search query
    /// </summary>
    [QueryParam("q")]
    public string? Query { get; init; }
    /// <summary>
    /// Filters content by level of access the user (logged in or anonymous) has to the track. The result list will include only tracks with the specified access. Include all options if you'd like to see all possible tracks.
    /// </summary>
    /// <remarks>If <see langword="null"/> or omitted, the request uses SoundCloud's default values:
    /// <see cref="Enums.Access.Playable"/>,
    /// <see cref="Enums.Access.Preview"/>
    /// </remarks>
    [QueryParam("access")]
    public Enums.Access[]? Access { get; init; }
    /// <summary>
    /// A boolean flag to request a playlist with or without tracks.
    /// </summary>
    /// <remarks>If <see langword="null"/> or omitted, the request uses SoundCloud's default value: true</remarks>
    [QueryParam("show_tracks")]
    public bool ShowTracks { get; init; } = true;
    /// <summary>
    /// Gets the pagination options to apply to the request.
    /// </summary>
    public PagingOptions? Page { get; init; } = new();
}