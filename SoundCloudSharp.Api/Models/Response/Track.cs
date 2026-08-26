using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Response;

/// <summary>
/// Soundcloud Track object.
/// </summary>
public record Track
{
    /// <summary>
    /// Type of object (track).
    /// </summary>
    public string Kind { get; init; }
    /// <summary>
    /// Track title.
    /// </summary>
    public string Title { get; init; }
    /// <summary>
    /// URL to a JPEG image.
    /// </summary>
    public Uri ArtworkUrl { get; init; }
    /// <summary>
    /// Tempo.
    /// </summary>
    public double Bpm { get; init; }
    /// <summary>
    /// Number of comments.
    /// </summary>
    public long CommentCount { get; init; }
    /// <summary>
    /// Is commentable.
    /// </summary>
    public bool Commentable { get; init; }
    /// <summary>
    /// Created timestamp.
    /// </summary>
    public DateTimeOffset CreatedAt { get; init; }
    /// <summary>
    /// Track description.
    /// </summary>
    public string Description { get; init; }
    /// <summary>
    /// Number of downloads.
    /// </summary>
    public long DownloadCount { get; init; }
    /// <summary>
    /// Is downloadable.
    /// </summary>
    public bool Downloadable { get; init; }
    /// <summary>
    /// Track duration in milliseconds.
    /// </summary>
    public int Duration { get; init; }
    /// <summary>
    /// Number of favoritings.
    /// </summary>
    public long FavoritingsCount { get; init; }
    /// <summary>
    /// Genre
    /// </summary>
    public string Genre { get; init; }
    /// <summary>
    /// Track URN identifier.
    /// </summary>
    public string Urn { get; init; }
    /// <summary>
    /// ISRC code.
    /// </summary>
    public string Isrc { get; init; }
    /// <summary>
    /// Key signature.
    /// </summary>
    public string KeySignature { get; init; }
    /// <summary>
    /// Label user name.
    /// </summary>
    public string LabelName { get; init; }
    /// <summary>
    /// License
    /// </summary>
    public Enums.License License { get; init; }
    /// <summary>
    /// Optional artist name, when different from user.
    /// </summary>
    public string MetadataArtist { get; init; }
    /// <summary>
    /// Permalink URL.
    /// </summary>
    public Uri PermalinkUrl { get; init; }
    /// <summary>
    /// Number of plays.
    /// </summary>
    public long PlaybackCount { get; init; }
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
    public int ReleaseDay {  get; init; }
    /// <summary>
    /// Month of release.
    /// </summary>
    public int ReleaseMonth { get; init; }
    /// <summary>
    /// Year of release.
    /// </summary>
    public int ReleaseYear { get; init; }
    /// <summary>
    /// Type of sharing (public/private).
    /// </summary>
    public Enums.Sharing Sharing { get; init; }
    /// <summary>
    /// Is streamable.
    /// </summary>
    public bool Streamable { get; init; }
    /// <summary>
    /// Tags.
    /// </summary>
    public string TagList { get; init; }
    /// <summary>
    /// Track URI.
    /// </summary>
    public Uri Uri { get; init; }
    /// <summary>
    /// User who uploaded a track
    /// </summary>
    public FullUser? User { get; init; }
    /// <summary>
    /// Is user's favourite. It is only set when fetching search results or single track, otherwise it is false.
    /// </summary>
    public bool UserFavorite { get; init; }
    /// <summary>
    /// Number of plays by a user.
    /// </summary>
    public int UserPlaybackCount { get; init; }
    /// <summary>
    /// Waveform URL.
    /// </summary>
    public Uri WaveformUrl { get; init; }
    /// <summary>
    /// List of country codes where track is available.
    /// </summary>
    public string AvailableCountryCodes { get; init; }
    /// <summary>
    /// Level of access the user (logged in or anonymous) has to the track.
    /// </summary>
    public Enums.Access? Access { get; init; }
    /// <summary>
    /// Level of access the user (logged in or anonymous) has to the track.
    /// </summary>
    public Uri? DownloadUrl { get; init; }
    /// <summary>
    /// Number of reposts.
    /// </summary>
    public int RepostsCount { get; init; }
    /// <summary>
    /// Whether play and favorite counts are visible. When false (quiet mode), stats are hidden.
    /// </summary>
    public bool RevealStats { get; init; }
    /// <summary>
    /// Secret URL.
    /// </summary>
    public Uri SecretUri { get; init; }
}