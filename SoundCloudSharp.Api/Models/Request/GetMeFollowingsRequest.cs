namespace SoundCloudSharp.Api.Models.Request;

public record GetMeFollowingsRequest
{
    public PagingOptions Paging { get; init; } = new();
}