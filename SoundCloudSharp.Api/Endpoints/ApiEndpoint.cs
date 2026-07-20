using SoundCloudSharp.Api.Http;

namespace SoundCloudSharp.Api.Endpoints;

public abstract class ApiEndpoint
{
    protected ApiConnector Connector { get; }

    protected ApiEndpoint(ApiConnector connector)
    {
        Connector = connector;
    }
    
    protected Dictionary<string, string> BuildQuery<T>(T request)
    {
        return request is null
            ? new Dictionary<string, string>()
            : QueryStringBuilder.Build(request);
    }
}