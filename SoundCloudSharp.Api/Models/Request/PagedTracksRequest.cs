using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record PagedTracksRequest
{
    public PagedRequest? Page { get; init; } = new ();
    public Enums.Access[]? Access { get; init; } = [Enums.Access.Playable, Enums.Access.Preview];
}