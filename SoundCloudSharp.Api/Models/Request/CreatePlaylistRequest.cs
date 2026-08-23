using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record CreatePlaylistRequest
{
    [FormField("playlist[title]")]
    public required string Title { get; init; }
    [FormField("playlist[description]")]
    public string? Description { get; init; }
    [FormField("playlist[sharing]")]
    public Enums.Sharing? Sharing { get; init; }
    [FormField("playlist[tracks][][urn]")]
    public List<string>? Tracks { get; init; }
    [FormField("playlist[artwork_data]")]
    public DataStream? ArtworkData { get; init; }
    [FormField("playlist[ean]")]
    public string? Ean { get; init; }
    [FormField("playlist[genre]")]
    public string? Genre { get; init; }
    [FormField("playlist[label_name]")]
    public string? LabelName { get; init; }
    [FormField("license")]
    public Enums.License? License { get; init; }
    [FormField("permalink")]
    public string? Permalink { get; init; }
    [FormField("permalink_url")]
    public Uri? PermalinkUrl { get; init; }
    [FormField("purchase_title")]
    public string? PurchaseTitle { get; init; }
    [FormField("purchase_url")]
    public Uri? PurchaseUrl { get; init; }
    [FormField("release")]
    public string? Release { get; init; }
    [FormField("release_date")]
    public DateTimeOffset? ReleaseDate { get; init; }
    [FormField("set_type")]
    public Enums.PlaylistType? SetType { get; init; }
    [FormField("tag_list")]
    public string? TagList { get; init; }
}
