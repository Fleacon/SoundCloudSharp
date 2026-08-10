namespace SoundCloudSharp.Api.Models.Request;

public record GetTrackCommentsRequest
{
    public PagingOptions Paging { get; init; } = new();
}