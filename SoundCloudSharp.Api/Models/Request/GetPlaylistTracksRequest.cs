using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record GetPlaylistTracksRequest
{
    [QueryParam("secret_token")]
    public string? SecretToken { get; init; }
    [QueryParam("access")]
    public Enums.Access[]? Accesses { get; init; }
    [QueryParam("linked_partitioning")]
    public bool LinkedPartitioning { get; init; } = true;
}