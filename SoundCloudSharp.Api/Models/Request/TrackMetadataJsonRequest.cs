using System.Text.Json.Serialization;
using SoundCloudSharp.Api.Models.Common;
using SoundCloudSharp.Api.Models.Converters;

namespace SoundCloudSharp.Api.Models.Request;

public record TrackMetadataJsonRequest
{
    public string? Title { get; init; }
    public string? Permalink { get; init; }
    [JsonConverter(typeof(StringEnumConverter<Enums.Sharing>))]
    public Enums.Sharing? Sharing { get; init; }
    [JsonConverter(typeof(StringEnumConverter<Enums.Embed>))]
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
    [JsonConverter(typeof(StringEnumConverter<Enums.License>))]
    public Enums.License? License { get; init; }
    public bool? Commentable { get; init; }
    public bool? RevealStats { get; init; }
    public bool? RevealComments { get; init; }
    public string? Isrc { get; init; }
}

public record TrackMetadataRequestEnvelope(TrackMetadataJsonRequest Track);

