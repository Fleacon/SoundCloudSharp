namespace SoundCloudSharp.Api.Models.Request;

public record CreateCommentRequest
{
    [QueryParam("body")] 
    public required string Body { get; init; }
    /// <summary>
    /// Timestamp of a comment
    /// </summary>
    [QueryParam("timestamp")]
    public TimeSpan? Timestamp { get; init; }
}

public record CreateCommentRequestEnvelope(CreateCommentRequest Comment);