using System.Text.Json.Serialization;
using SoundCloudSharp.Api.Models.Common;
using SoundCloudSharp.Api.Models.Converters;

namespace SoundCloudSharp.Api.Models.Request;

public class TrackMetadataFormRequest
{
    public string? Title { get; init; }
    public string? Permalink { get; init; }
    public Enums.Sharing? Sharing { get; init; }
    public Enums.Embed? EmbeddableBy { get; init; }
    public string? PurchaseUrl { get; init; }
    public string? Description { get; init; }
    public string? Genre { get; init; }
    public string? TagList { get; init; }
    public string? LabelName { get; init; }
    public string? Release { get; init; }
    public DateOnly? ReleaseDate { get; init; }
    public bool? Streamable { get; init; }
    public bool? Downloadable { get; init; }
    public Enums.License? License { get; init; }
    public bool? Commentable { get; init; }
    public bool? RevealStats { get; init; }
    public bool? RevealComments { get; init; }
    public string? Isrc { get; init; }
    public FileStream? ArtworkData { get; init; }
}