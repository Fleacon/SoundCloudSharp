namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetMeLikedPlaylistsRequest
{
    public PagingOptions Paging { get; init; } = new();
}