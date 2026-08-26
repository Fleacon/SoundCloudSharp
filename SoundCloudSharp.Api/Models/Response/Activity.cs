namespace SoundCloudSharp.Api.Models.Response;

public abstract record Activity
{
    /// <summary>
    /// Type of activity (e.g. track, track:repost, playlist, playlist:repost). For track:repost and playlist:repost, the API also returns a top-level string field reposter with the URN of the user who reposted.
    /// </summary>
    public string Type { get; init; }
    /// <summary>
    /// Created timestamp.
    /// </summary>
    public DateTimeOffset CreatedAt { get; init; }
}