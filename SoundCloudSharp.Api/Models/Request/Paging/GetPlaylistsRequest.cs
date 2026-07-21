namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetMePlaylistsRequest
{
    public PagingOptions Paging { get; init; } = new();
    public bool? ShowTracks { get; init; }
}