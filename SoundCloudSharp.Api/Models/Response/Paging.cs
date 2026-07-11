namespace SoundCloudSharp.Api.Models.Response;

public class Paging<T>
{
    public List<T> Collection { get; init; }
    public Uri NextHref { get; init; }
}