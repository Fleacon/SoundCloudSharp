namespace SoundCloudSharp.Api.Models.Response;

public record PlaylistActivity : Activity
{
    /// <summary>
    /// Soundcloud Playlist Object
    /// </summary>
    public Playlist Origin { get; init; } 
}