using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record GetMeRecentlyPlayedTracksRequest
{
    [QueryParam("access")]
    public Enums.Access[]? Access { get; init; } 
}