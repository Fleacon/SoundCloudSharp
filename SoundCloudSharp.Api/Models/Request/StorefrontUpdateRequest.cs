using System.ComponentModel.DataAnnotations;
using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record StorefrontUpdateRequest([property: StringLength(100)] string Title, Enums.StoreType Type, Uri Link)
{
    [property: StringLength(50)]
    public string? LinkTitle { get; init; }
    [property: StringLength(500)]
    public string? Description { get; init; }
    public string? Price { get; init; }
}