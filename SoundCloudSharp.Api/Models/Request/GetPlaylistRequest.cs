using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record GetPlaylistRequest
{
    public string? SecretToken { get; init; }
    public Enums.Access[]? Accesses { get; init; }
    public bool ShowTracks { get; init; } = true;
}