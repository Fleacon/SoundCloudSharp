using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record GetPlaylistTracksRequest
{
    public string? SecretToken { get; init; }
    public Enums.Access[]? Accesses { get; init; }
    public bool LinkedPartitioning { get; init; } = true;
}