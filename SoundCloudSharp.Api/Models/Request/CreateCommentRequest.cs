namespace SoundCloudSharp.Api.Models.Request;

public record CreateCommentRequest(string Body)
{
    public string Timestamp { get; init; }
}

public record CreateCommentRequestEnvelope(CreateCommentRequest Comment);