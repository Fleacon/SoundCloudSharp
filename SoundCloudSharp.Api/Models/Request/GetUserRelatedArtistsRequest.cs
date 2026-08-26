namespace SoundCloudSharp.Api.Models.Request;

public record GetUserRelatedArtistsRequest
{
    /// <summary>
    /// Gets the pagination options to apply to the request.
    /// </summary>
    PagingOptions Paging { get; init; } = new();
}