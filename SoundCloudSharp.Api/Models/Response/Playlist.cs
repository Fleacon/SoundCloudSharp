using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Response;

/// <summary>
/// Soundcloud Playlist Object
/// </summary>
public record Playlist
{
    /// <summary>
    /// Playlist title.
    /// </summary>
    public string Title { get; init; }
    /// <summary>
    /// Playlist identifier.
    /// </summary>
    public string Urn { get; init; }
    /// <summary>
    /// Type of Soundcloud object (playlist).
    /// </summary>
    public string Kind { get; init; }
    /// <summary>
    /// URL to a JPEG image.
    /// </summary>
    public Uri ArtworkUrl { get; init; }
    /// <summary>
    /// Created timestamp.
    /// </summary>
    public DateTimeOffset CreatedAt { get; init; }
    /// <summary>
    /// Playlist description.
    /// </summary>
    public string Description { get; init; }
    /// <summary>
    /// is downloadable.
    /// </summary>
    public bool Downloadable { get; init; }
    /// <summary>
    /// Playlist duration.
    /// </summary>
    public int Duration { get; init; }
    /// <summary>
    /// European Article Number.
    /// </summary>
    public string Ean { get; init; }
    /// <summary>
    /// Embeddable by.
    /// </summary>
    public Enums.Embed EmbeddableBy { get; init; }
    /// <summary>
    /// Playlist genre.
    /// </summary>
    public string Genre { get; init; }
    /// <summary>
    /// Label user identifier.
    /// </summary>
    public int LabelId { get; init; }
    /// <summary>
    /// Label name.
    /// </summary>
    public string LabelName { get; init; }
    /// <summary>
    /// Last modified timestamp.
    /// </summary>
    public DateTimeOffset LastModified { get; init; }
    /// <summary>
    /// License.
    /// </summary>
    public Enums.License License { get; init; }
    /// <summary>
    /// Playlist permalink.
    /// </summary>
    public string Permalink { get; init; }
    /// <summary>
    /// Playlist permalink URL.
    /// </summary>
    public Uri PermalinkUrl { get; init; }
    /// <summary>
    /// Type of playlist.
    /// </summary>
    public string PlaylistType { get; init; }
    /// <summary>
    /// Purchase title.
    /// </summary>
    public string PurchaseTitle { get; init; }
    /// <summary>
    /// Purchase URL.
    /// </summary>
    public Uri PurchaseUrl { get; init; }
    /// <summary>
    /// Release.
    /// </summary>
    public string Release { get; init; }
    /// <summary>
    /// Day of release.
    /// </summary>
    public int ReleaseDay { get; init; }
    /// <summary>
    /// Month of release.
    /// </summary>
    public int ReleaseMonth { get; init; }
    /// <summary>
    /// Year of release.
    /// </summary>
    public int ReleaseYear { get; init; }
    /// <summary>
    /// Type of sharing (private/public).
    /// </summary>
    public Enums.Sharing Sharing  { get; init; }
    /// <summary>
    /// Is streamable.
    /// </summary>
    public bool Streamable { get; init; }
    /// <summary>
    /// Tags.
    /// </summary>
    public string TagList { get; init; }
    /// <summary>
    /// Count of tracks.
    /// </summary>
    public int TrackCount { get; init; }
    /// <summary>
    /// List of tracks.
    /// </summary>
    public List<Track> Tracks { get; init; }
    /// <summary>
    /// Playlist type.
    /// </summary>
    public Enums.PlaylistType Type { get; init; }
    /// <summary>
    /// Playlist URI.
    /// </summary>
    public Uri Uri { get; init; }
    /// <summary>
    /// SoundCloud User object
    /// </summary>
    public FullUser? User { get; init; }
    /// <summary>
    /// User identifier.
    /// </summary>
    public string UserUrn { get; init; }
    /// <summary>
    /// Count of playlist likes.
    /// </summary>
    public int LikesCount { get; init; }
    /// <summary>
    /// SoundCloud User object
    /// </summary>
    public FullUser? Label { get; init; }
    /// <summary>
    /// tracks URI.
    /// </summary>
    public Uri? TracksUri { get; init; }
    /// <summary>
    /// Tags.
    /// </summary>
    public string Tags { get; init; }
}