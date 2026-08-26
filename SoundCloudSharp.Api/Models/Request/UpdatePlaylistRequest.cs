using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record UpdatePlaylistRequest
{
    /// <summary>
    /// Title of the playlist
    /// </summary>
    public string? Title { get; init; }
    /// <summary>
    /// Description of the playlist
    /// </summary>
    public string? Description { get; init; }
    /// <summary>
    /// public or private
    /// </summary>
    public Enums.Sharing? Sharing { get; init; }
    /// <summary>
    /// List of tracks to add to playlist
    /// </summary>
    public List<string>? Tracks { get; init; }
    /// <summary>
    /// The European Article Number
    /// </summary>
    public string? Ean { get; init; }
    /// <summary>
    /// Playlist's genre
    /// </summary>
    public string? Genre { get; init; }
    /// <summary>
    /// Label name
    /// </summary>
    public string? LabelName { get; init; }
    /// <summary>
    /// License number
    /// </summary>
    public Enums.License? License { get; init; }
    /// <summary>
    /// Playlist's permalink
    /// </summary>
    public string? Permalink { get; init; }
    /// <summary>
    /// Full permalink URL
    /// </summary>
    public Uri? PermalinkUrl { get; init; }
    /// <summary>
    /// Purchase title
    /// </summary>
    public string? PurchaseTitle { get; init; }
    /// <summary>
    /// Purchase URL
    /// </summary>
    public Uri? PurchaseUrl { get; init; }
    /// <summary>
    /// Playlist's release
    /// </summary>
    public string? Release { get; init; }
    /// <summary>
    /// Release date
    /// </summary>
    public DateTimeOffset? ReleaseDate { get; init; }
    /// <summary>
    /// Playlist or album type
    /// </summary>
    public Enums.PlaylistType? SetType { get; init; }
    /// <summary>
    /// A list of tags
    /// </summary>
    public string? TagList { get; init; }
}

public record UpdatePlaylistRequestEnvelope(UpdatePlaylistRequest Playlist);