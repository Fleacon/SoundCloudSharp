namespace SoundCloudSharp.Api.Models.Request;

public record GetMeLikedPlaylistsRequest
{
    public PagingOptions Paging { get; init; } = new();
}