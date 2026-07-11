using Newtonsoft.Json;
using SoundCloudSharp.Api.Models.Common;
using SoundCloudSharp.Api.Models.Converters;

namespace SoundCloudSharp.Api.Models.Response;

public record Track
{
    public string Kind { get; init; }
    public string Title { get; init; }
    public Uri ArtworkUrl { get; init; }
    public double Bpm { get; init; }
    public long CommentCount { get; init; }
    public bool Commentable { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public string Description { get; init; }
    public long DownloadCount { get; init; }
    public bool Downloadable { get; init; }
    public int Duration { get; init; }
    public long FavoritingsCount { get; init; }
    public string Genre { get; init; }
    public string Urn { get; init; }
    public string Isrc { get; init; }
    public string KeySignature { get; init; }
    public string LabelName { get; init; }
    [JsonConverter(typeof(StringEnumConverter<Enums.License>))]
    public Enums.License License { get; init; }
    public string MetadataArtist { get; init; }
    public Uri PermalinkUrl { get; init; }
    public long PlaybackCount { get; init; }
    public string PurchaseTitle { get; init; }
    public Uri PurchaseUrl { get; init; }
    public string Release { get; init; }
    public int ReleaseDay {  get; init; }
    public int ReleaseMonth { get; init; }
    public int ReleaseYear { get; init; }
    [JsonConverter(typeof(StringEnumConverter<Enums.Sharing>))]
    public Enums.Sharing Sharing { get; init; }
    public bool Streamable { get; init; }
    public string TagList { get; init; }
    public Uri Uri { get; init; }
    public FullUser? User { get; init; }
    public bool UserFavorite { get; init; }
    public int UserPlaybackCount { get; init; }
    public Uri WaveformUrl { get; init; }
    public string AvailableCountryCodes { get; init; }
    [JsonConverter(typeof(StringEnumConverter<Access>))]
    public Access? Access { get; init; }
    public Uri DownloadUrl { get; init; }
    public int RepostsCount { get; init; }
    public bool RevealStats { get; init; }
    public Uri SecretUri { get; init; }
}

public enum Access
{
    Unknown = 0,
    Playable,
    Preview,
    Blocked
}