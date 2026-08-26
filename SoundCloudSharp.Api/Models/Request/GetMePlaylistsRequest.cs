namespace SoundCloudSharp.Api.Models.Request;

public record GetMePlaylistsRequest
{
    /// <summary>
    /// Gets the pagination options to apply to the request.
    /// </summary>
    public PagingOptions Paging { get; init; } = new();
    /// <summary>
    /// A boolean flag to request a playlist with or without tracks.
    /// </summary>
    /// <remarks>If <see langword="null"/> or omitted, the request uses SoundCloud's default value: true </remarks>
    [QueryParam("show_tracks")]
    public bool? ShowTracks { get; init; }
}