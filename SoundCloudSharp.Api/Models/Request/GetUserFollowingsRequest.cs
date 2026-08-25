namespace SoundCloudSharp.Api.Models.Request;

public record GetUserFollowingsRequest
{
    public PagingOptions Paging { get; init; } = new();
}