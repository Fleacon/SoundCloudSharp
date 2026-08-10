namespace SoundCloudSharp.Api.Models.Request;

public record GetMePlaylistsRequest
{
    public PagingOptions Paging { get; init; } = new();
    [QueryParam("show_tracks")]
    public bool? ShowTracks { get; init; }
}