using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record GetUserPlaylistsRequest
{
    /// <summary>
    /// Gets the pagination options to apply to the request.
    /// </summary>
    public PagingOptions Paging { get; init; } = new();
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
    /// <remarks><remarks>If <see langword="null"/> or omitted, the request uses SoundCloud's default value: true</remarks></remarks>
    [QueryParam("show_tracks")]
    public bool ShowTracks { get; init; }
}