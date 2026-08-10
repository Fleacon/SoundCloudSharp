using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record GetUserPlaylistsRequest
{
    public PagingOptions Paging { get; init; } = new();
    [QueryParam("access")]
    public Enums.Access[]? Access { get; init; }
    [QueryParam("show_tracks")]
    public bool ShowTracks { get; init; }
}