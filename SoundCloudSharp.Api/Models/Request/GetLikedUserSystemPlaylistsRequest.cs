namespace SoundCloudSharp.Api.Models.Request;

public record GetLikedUserSystemPlaylistsRequest
{
    /// <summary>
    /// Gets the pagination options to apply to the request.
    /// </summary>
    public PagingOptions Paging { get; init; } = new();
}