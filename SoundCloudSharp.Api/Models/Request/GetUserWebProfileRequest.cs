namespace SoundCloudSharp.Api.Models.Request;

public record GetUserWebProfileRequest
{
    public PagingOptions Paging { get; init; } = new();
}