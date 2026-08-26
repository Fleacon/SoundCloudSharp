using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record TrackDataRequest
{
    
    [FormField("track[title]")]
    public required string Title { get; init; }
    
    public required DataStream AssetData { get; init; }
    /// <summary>
    /// Optional artist name for the track.
    /// </summary>
    [FormField("track[artist]")]
    public string artist { get; init; }
    
    [FormField("track[permalink]")]
    public Uri? Permalink { get; init; }
    
    [FormField("track[sharing]")]
    public Enums.Sharing? Sharing { get; init; }
    /// <summary>
    /// who can embed this track <see cref="Enums.Embed.All"/>, <see cref="Enums.Embed.Me"/> or <see cref="Enums.Embed.None"/>
    /// </summary>
    [FormField("track[embeddable_by]")]
    public Enums.Embed? EmbeddableBy { get; init; }
    
    [FormField("track[purchase_url]")]
    public Uri? PurchaseUrl { get; init; }
    
    [FormField("track[genre]")]
    public string? Genre { get; init; }
    
    [FormField("track[tag_list]")]
    public string[]? TagList { get; init; }
    
    [FormField("track[label_name]")]
    public string? LabelName { get; init; }
    
    [FormField("track[release]")]
    public string? Release { get; init; }
    
    [FormField("track[release_date]")]
    public DateTimeOffset? ReleaseDate { get; init; }
    
    [FormField("track[streamable]")]
    public bool? Streamable { get; init; }
    
    [FormField("track[downloadable]")]
    public bool? Downloadable { get; init; }
    
    [FormField("track[license]")]
    public Enums.License? License { get; init; }
    
    [FormField("track[commentable]")]
    public bool? Commentable { get; init; }
    /// <summary>
    /// When false (quiet mode), play and favorite counts are hidden.
    /// </summary>
    [FormField("track[reveal_stats]")]
    public bool? RevealStats { get; init; }
    /// <summary>
    /// When false (quiet mode), comments are hidden.
    /// </summary>
    [FormField("track[reveal_comments]")]
    public bool? RevealComments { get; init; }
    
    [FormField("track[isrc]")]
    public string? Isrc { get; init; }
    
    public DataStream? ArtworkData { get; init; }
}