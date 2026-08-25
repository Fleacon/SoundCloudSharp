namespace SoundCloudSharp.Api.Models.Request;

public record GetUserFollowersRequest
{
    public PagingOptions Paging { get; init; } = new();
}