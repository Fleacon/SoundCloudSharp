namespace SoundCloudSharp.Api.Models.Response;
   
public class ActivityPaging : Paging<Activity>
{
   public Uri FutureHref { get; init; } 
}