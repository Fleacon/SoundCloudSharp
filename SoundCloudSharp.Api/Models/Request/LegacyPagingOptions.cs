namespace SoundCloudSharp.Api.Models.Request;

public record LegacyPagingOptions : PagingOptions
{
    [Obsolete("Deprecated by SoundCLoud. Use LinkedPartitioning instead.")]
    [QueryParam("offset")]
    public int? Offset { get; init; }
}