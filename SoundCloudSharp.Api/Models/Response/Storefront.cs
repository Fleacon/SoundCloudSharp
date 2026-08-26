using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Response;

/// <summary>
/// A track's storefront (Artist Storefront / buy module) shown on the track page.
/// </summary>
public record Storefront
{
    /// <summary>
    /// The urn of the track the storefront belongs to.
    /// </summary>
    public string TrackUrn { get; init; }
    /// <summary>
    /// Card title shown on the storefront module.
    /// </summary>
    public string Title  { get; init; }
    /// <summary>
    /// The type of item offered.
    /// </summary>
    public Enums.StoreType Type { get; init; }
    /// <summary>
    /// External URL the storefront button opens.
    /// </summary>
    public Uri? Link { get; init; }
    /// <summary>
    /// Label of the storefront button.
    /// </summary>
    public string? LinkTitle { get; init; }
    /// <summary>
    /// Description shown on the storefront module.
    /// </summary>
    public string? Description { get; init; }
    /// <summary>
    /// Image shown on the storefront module. Read-only; managed on soundcloud.com.
    /// </summary>
    public Uri? ImageUrl { get; init; }
    /// <summary>
    /// Display-only price text shown next to the item type. No payment is processed by SoundCloud.
    /// </summary>
    public string? Price { get; init; }
}