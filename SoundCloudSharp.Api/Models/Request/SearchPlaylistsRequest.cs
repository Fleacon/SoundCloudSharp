using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record SearchPlaylistsRequest
{
    public string? Query { get; init; }
    public Enums.Access[]? Access { get; init; }
    public bool ShowTracks { get; init; } = true;
    public PagedRequest? Page { get; init; } = new();
}