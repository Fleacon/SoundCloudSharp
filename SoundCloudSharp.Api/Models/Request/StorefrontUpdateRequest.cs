using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

/// <summary>
/// Creates or updates the storefront (Artist Storefront / buy module) of a track. The request replaces the whole storefront - omitted optional fields are cleared, so always send every value the storefront should keep.
/// </summary>
public record StorefrontUpdateRequest
{
    /// <summary>
    /// Card title shown on the storefront module.
    /// </summary>
    /// <remarks>maxLength: 100</remarks>
    public required string Title { get; init; }
    /// <summary>
    /// The type of item offered.
    /// </summary>
    public required Enums.StoreType Type { get; init; }
    /// <summary>
    /// External http(s) URL the storefront button opens.
    /// </summary>
    /// <remarks>maxLength: 255</remarks>
    public required string Link { get; init; }
    /// <summary>
    /// Label of the storefront button. Omit to clear.
    /// </summary>
    /// <remarks>maxLength: 50</remarks>
    public string? LinkTitle { get; init; }
    /// <summary>
    /// Description shown on the storefront module. Omit to clear.
    /// </summary>
    /// <remarks>maxLength: 500</remarks>
    public string? Description { get; init; }
    /// <summary>
    /// Display-only price text shown next to the item type. No payment is processed by SoundCloud. Omit to clear.
    /// </summary>
    /// <remarks>maxLength: 20</remarks>
    public string? Price { get; init; }
}