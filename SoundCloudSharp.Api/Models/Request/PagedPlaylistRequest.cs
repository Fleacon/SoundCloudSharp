namespace SoundCloudSharp.Api.Models.Request;

public record PagedPlaylistRequest
{
    public PagedRequest? Page { get; init; } = new();
    public bool ShowTracks { get; init; } = true;
}