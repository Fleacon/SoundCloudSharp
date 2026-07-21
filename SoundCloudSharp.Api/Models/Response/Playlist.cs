using System.Text.Json.Serialization;
using SoundCloudSharp.Api.Models.Common;
using SoundCloudSharp.Api.Models.Converters;

namespace SoundCloudSharp.Api.Models.Response;

public record Playlist
{
    public string Title { get; init; }
    public string Urn { get; init; }
    public string Kind { get; init; }
    public Uri ArtworkUrl { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public string Description { get; init; }
    public bool Downloadable { get; init; }
    public int Duration { get; init; }
    public string Ean { get; init; }
    public Enums.Embed EmbeddableBy { get; init; }
    public string Genre { get; init; }
    public int LabelId { get; init; }
    public string LabelName { get; init; }
    public DateTimeOffset LastModified { get; init; }
    public Enums.License License { get; init; }
    public string Permalink { get; init; }
    public Uri PermalinkUrl { get; init; }
    public string PlaylistType { get; init; }
    public string PurchaseTitle { get; init; }
    public Uri PurchaseUrl { get; init; }
    public string Release { get; init; }
    public int ReleaseDay { get; init; }
    public int ReleaseMonth { get; init; }
    public int ReleaseYear { get; init; }
    public Enums.Sharing Sharing  { get; init; }
    public bool Streamable { get; init; }
    public string TagList { get; init; }
    public int TrackCount { get; init; }
    public List<Track> Tracks { get; init; }
    public Enums.PlaylistType Type { get; init; }
    public Uri Uri { get; init; }
    public FullUser? User { get; init; }
    public string UserUrn { get; init; }
    public int LikesCount { get; init; }
    public FullUser? Label { get; init; }
    public Uri? TracksUri { get; init; }
    public string Tags { get; init; }
}