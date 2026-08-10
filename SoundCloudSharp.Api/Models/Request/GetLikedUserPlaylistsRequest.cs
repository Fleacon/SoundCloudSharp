namespace SoundCloudSharp.Api.Models.Request;

public record GetLikedUserPlaylistsRequest
{
    public PagingOptions Paging { get; init; } = new();
}