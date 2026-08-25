using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record CreatePlaylistRequest
{
    /// <summary>
    /// Title of the playlist
    /// </summary>
    [FormField("playlist[title]")]
    public required string Title { get; init; }
    /// <summary>
    /// Description of the playlist
    /// </summary>
    [FormField("playlist[description]")]
    public string? Description { get; init; }
    /// <summary>
    /// public or private
    /// </summary>
    [FormField("playlist[sharing]")]
    public Enums.Sharing? Sharing { get; init; }
    /// <summary>
    /// List of tracks to add to playlist
    /// </summary>
    [FormField("playlist[tracks][][urn]")]
    public List<string>? Tracks { get; init; }
    /// <summary>
    /// Artwork data
    /// </summary>
    [FormField("playlist[artwork_data]")]
    public DataStream? ArtworkData { get; init; }
    /// <summary>
    /// The European Article Number
    /// </summary>
    [FormField("playlist[ean]")]
    public string? Ean { get; init; }
    /// <summary>
    /// Playlist's genre
    /// </summary>
    [FormField("playlist[genre]")]
    public string? Genre { get; init; }
    /// <summary>
    /// Label name
    /// </summary>
    [FormField("playlist[label_name]")]
    public string? LabelName { get; init; }
    /// <summary>
    /// License number
    /// </summary>
    [FormField("license")]
    public Enums.License? License { get; init; }
    /// <summary>
    /// Playlist's permalink
    /// </summary>
    [FormField("permalink")]
    public string? Permalink { get; init; }
    /// <summary>
    /// Full permalink URL
    /// </summary>
    [FormField("permalink_url")]
    public Uri? PermalinkUrl { get; init; }
    /// <summary>
    /// Purchase title
    /// </summary>
    [FormField("purchase_title")]
    public string? PurchaseTitle { get; init; }
    /// <summary>
    /// Purchase URL
    /// </summary>
    [FormField("purchase_url")]
    public Uri? PurchaseUrl { get; init; }
    /// <summary>
    /// Playlist's release
    /// </summary>
    [FormField("release")]
    public string? Release { get; init; }
    /// <summary>
    /// Release date
    /// </summary>
    [FormField("release_date")]
    public DateTimeOffset? ReleaseDate { get; init; }
    /// <summary>
    /// Playlist or album type
    /// </summary>
    [FormField("set_type")]
    public Enums.PlaylistType? SetType { get; init; }
    /// <summary>
    /// List of tags
    /// </summary>
    [FormField("tag_list")]
    public string? TagList { get; init; }
}
