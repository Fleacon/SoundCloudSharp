namespace SoundCloudSharp.Api.Models.Response;

public record PlaylistActivity : Activity
{
    public required Playlist Origin { get; init; } 
}