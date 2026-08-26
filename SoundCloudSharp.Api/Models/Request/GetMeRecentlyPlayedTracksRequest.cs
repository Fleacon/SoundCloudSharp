using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record GetMeRecentlyPlayedTracksRequest
{
    /// <summary>
    /// Filters content by level of access the user (logged in or anonymous) has to the track. The result list will include only tracks with the specified access. Include all options if you'd like to see all possible tracks.
    /// </summary>
    /// <remarks>If <see langword="null"/> or omitted, the request uses SoundCloud's default values:
    /// <see cref="Enums.Access.Playable">Playable</see>,
    /// <see cref="Enums.Access.Preview">Preview</see>
    /// </remarks>
    [QueryParam("access")]
    public Enums.Access[]? Access { get; init; } 
}