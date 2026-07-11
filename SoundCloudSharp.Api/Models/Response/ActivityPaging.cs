namespace SoundCloudSharp.Api.Models.Response

public class ActivityPaging<T> : Paging<T>
{
   public Uri FutureHref { get; init; } 
}