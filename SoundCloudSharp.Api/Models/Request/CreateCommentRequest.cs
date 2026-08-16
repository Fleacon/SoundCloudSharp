namespace SoundCloudSharp.Api.Models.Request;

public record CreateCommentRequest(string body)
{
    [QueryParam("body")] 
    public string Body { get; init; } = body;
    [QueryParam("timestamp")]
    public string Timestamp { get; init; }
}

public record CreateCommentRequestEnvelope(CreateCommentRequest Comment);