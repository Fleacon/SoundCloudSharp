using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record GetMeTracksRequest
{
    /// <summary>
    /// Gets the pagination options to apply to the request.
    /// </summary>
    public PagingOptions Paging { get; init; } = new();
    /// <summary>
    /// Sort order of tracks by upload date. <see cref="Enums.Sort.Desc"/> returns newest tracks first; <see cref="Enums.Sort.Asc"/> returns oldest first.
    /// </summary>
    /// <remarks>If <see langword="null"/> or omitted, the request uses SoundCloud's default value: <see cref="Enums.Sort.Desc"/></remarks>
    [QueryParam("sort")]
    public Enums.Sort? Sort { get; init; }
}