using SoundCloudSharp.Api.Models.Common;
using SoundCloudSharp.Api.Models.Request.Paging;

namespace SoundCloudSharp.Api.Models.Request;

public record SearchPlaylistsRequest
{
    [QueryParam("q")]
    public string? Query { get; init; }
    [QueryParam("access")]
    public Enums.Access[]? Access { get; init; }
    [QueryParam("show_tracks")]
    public bool ShowTracks { get; init; } = true;
    public PagingOptions? Page { get; init; } = new();
}