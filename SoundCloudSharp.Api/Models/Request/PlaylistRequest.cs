using System.Text.Json.Serialization;
using SoundCloudSharp.Api.Models.Common;
using SoundCloudSharp.Api.Models.Converters;

namespace SoundCloudSharp.Api.Models.Request;

public record PlaylistRequest
{
    public string Title { get; init; }
    public string Description { get; init; }
    public Enums.Sharing Sharing { get; init; }
    public List<TrackReference> Tracks { get; init; }
    public Stream ArtworkData { get; init; }
    public string Ean { get; init; }
    public string Genre { get; init; }
    public string LabelName { get; init; }
    public Enums.License License { get; init; }
    public string Permalink { get; init; }
    public Uri PermalinkUrl { get; init; }
    public string PurchaseTitle { get; init; }
    public Uri PurchaseUrl { get; init; }
    public string Release { get; init; }
    public DateTimeOffset ReleaseDate { get; init; }
    public Enums.PlaylistType SetType { get; init; }
    public string TagList { get; init; }
}