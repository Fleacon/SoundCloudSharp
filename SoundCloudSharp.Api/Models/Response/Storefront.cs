using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Response;

public record Storefront
{
    public string TrackUrn { get; init; }
    public string Title  { get; init; }
    public Enums.StoreType Type { get; init; }
    public Uri? Link { get; init; }
    public string? LinkTitle { get; init; }
    public string? Description { get; init; }
    public Uri? ImageUrl { get; init; }
    public string? Price { get; init; }
}