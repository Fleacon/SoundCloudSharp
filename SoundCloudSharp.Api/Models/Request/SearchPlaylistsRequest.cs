using SoundCloudSharp.Api.Models.Common;
using SoundCloudSharp.Api.Models.Request.Paging;

namespace SoundCloudSharp.Api.Models.Request;

public record SearchPlaylistsRequest
{
    public string? Query { get; init; }
    public Enums.Access[]? Access { get; init; }
    public bool ShowTracks { get; init; } = true;
    public PagingOptions? Page { get; init; } = new();
}