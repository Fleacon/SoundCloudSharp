using SoundCloudSharp.Api.Http;

namespace SoundCloudSharp.Api.Endpoints;

public abstract class ApiEndpoint(ApiConnector connector)
{
    protected ApiConnector Connector { get; } = connector;

    protected static Dictionary<string, string> BuildQuery<T>(T request)
    {
        return request is null
            ? new Dictionary<string, string>()
            : QueryStringBuilder.Build(request);
    }
}