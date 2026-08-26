namespace SoundCloudSharp.Api.Models.Response;

public record FoundResponse
{
    /// <summary>
    /// Status code
    /// </summary>
    public string Status;
    /// <summary>
    /// Location URL of the resource.
    /// </summary>
    public Uri Location;
}