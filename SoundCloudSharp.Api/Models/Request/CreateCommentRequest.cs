namespace SoundCloudSharp.Api.Models.Request;

public record CreateCommentRequest
{
    [QueryParam("body")]
    public required string Body { get; init; }
    [QueryParam("timestamp")]
    public string Timestamp { get; init; }
}

public record CreateCommentRequestEnvelope(CreateCommentRequest Comment);