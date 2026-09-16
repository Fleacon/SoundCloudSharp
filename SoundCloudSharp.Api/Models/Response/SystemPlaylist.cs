using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Response;

/// <summary>
/// SoundCloud system playlist object (e.g. track station, artist station).
/// </summary>
public record SystemPlaylist
{
    /// <summary>
    /// Type of object (system-playlist).
    /// </summary>
    public string Kind { get; init; }
    /// <summary>
    /// System playlist URN.
    /// </summary>
    public string Urn { get; init; }
    /// <summary>
    /// Playlist title.
    /// </summary>
    public string Title { get; init; }
    /// <summary>
    /// Playlist description.
    /// </summary>
    public string Description { get; init; }
    /// <summary>
    /// Playlist type.
    /// </summary>
    public string PlaylistType { get; init; }
    /// <summary>
    /// System playlist permalink slug.
    /// </summary>
    public string Permalink { get; init; }
    /// <summary>
    /// Permalink URL on soundcloud.com.
    /// </summary>
    public Uri PermalinkUrl { get; init; }
    /// <summary>
    /// Last updated timestamp.
    /// </summary>
    public DateTimeOffset? LastUpdated { get; init; }
    /// <summary>
    /// Tracking feature name.
    /// </summary>
    public string? TrackingFeatureName { get; init; }
    /// <summary>
    /// Number of visible tracks in the playlist.
    /// </summary>
    public int TrackCount { get; init; }
    /// <summary>
    /// Query URN used to generate the playlist, when available.
    /// </summary>
    public string? QueryUrn { get; init; }
    /// <summary>
    /// Visible tracks in the playlist
    /// </summary>
    public List<Track> Tracks { get; init; }
}