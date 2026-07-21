namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetMeFollowingsRequest
{
    public PagingOptions Paging { get; init; } = new();
}