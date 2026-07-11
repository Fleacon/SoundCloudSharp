namespace SoundCloudSharp.Api.Models.Request;

public record CreateUpdatePlaylistRequest
{
    public PlaylistRequest Playlist { get; init; }
}