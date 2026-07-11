namespace SoundCloudSharp.Api.Models.Response;

public abstract record Activity
{
    public string Type  { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
}