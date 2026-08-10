using System.ComponentModel.DataAnnotations;
using SoundCloudSharp.Api.Models.Common;

namespace SoundCloudSharp.Api.Models.Request;

public record StorefrontUpdateRequest(string Title, Enums.StoreType Type, Uri Link)
{
    public string? LinkTitle { get; init; }
    public string? Description { get; init; }
    public string? Price { get; init; }
}