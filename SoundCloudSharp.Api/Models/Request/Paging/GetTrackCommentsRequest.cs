namespace SoundCloudSharp.Api.Models.Request.Paging;

public record GetTrackCommentsRequest
{
    public PagingOptions Paging { get; init; } = new();
}