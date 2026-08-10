using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record GetPlaylistsRequest
{
    [QueryParam("secret_token")]
    public string? SecretToken { get; init; }
    [QueryParam("access")]
    public Enums.Access[]?Accesses { get; init; }
    [QueryParam("show_tracks")]
    public bool ShowTracks { get; init; } = true;
}