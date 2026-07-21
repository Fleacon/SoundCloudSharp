namespace SoundCloudSharp.Api.Models.Request.Paging;

public record LegacyPagingOptions : PagingOptions
{
    [Obsolete("Deprecated by SoundCLoud. Use LinkedPartitioning instead.")]
    public int? Offset { get; init; }
}