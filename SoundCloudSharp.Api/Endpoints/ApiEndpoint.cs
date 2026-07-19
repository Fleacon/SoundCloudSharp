using System.Text;
using SoundCloudSharp.Api.Http;

namespace SoundCloudSharp.Api.Endpoints;

public abstract class ApiEndpoint
{
    protected ApiConnector Connector { get; }

    protected ApiEndpoint(ApiConnector connector)
    {
        Connector = connector;
    }

    protected Uri BuildUriWithQuery(Uri endpoint, IDictionary<string, string> query)
    {
        if (query.Count == 0)
            return endpoint;

        var queryString = string.Join("&",
            query.Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));

        return new Uri($"{endpoint}?{queryString}", UriKind.Relative);
    }
    
    protected Dictionary<string, string> BuildQuery<T>(T request)
    {
        return request is null
            ? new Dictionary<string, string>()
            : QueryStringBuilder.Build(request);
    }
}