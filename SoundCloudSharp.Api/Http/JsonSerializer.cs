using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SoundCloudSharp.Api.Models.Converters;

namespace SoundCloudSharp.Api.Http;

public class JsonSerializer
{
    private readonly JsonSerializerSettings _settings;
    
    public JsonSerializer()
    {
        _settings = new JsonSerializerSettings
        {
            Converters =
            {
                new ActivityConverter(),
                new DateConverter()
            },
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };
    }
    
    public DeserializedResponse<T> DeserializeResponse<T>(Response response)
    {
        if (response.ContentType?.Equals("application/json", StringComparison.OrdinalIgnoreCase) is true)
        {
            var body  = JsonConvert.DeserializeObject<T>(response.Body as string ?? "", _settings);
            return new DeserializedResponse<T>(response, body);
        }

        return new DeserializedResponse<T>(response);
    }

    public Request SerializeRequest(Request request)
    {
        if (request.Body is string or Stream or HttpContent or null)
            return request;

        return request with { Body = JsonConvert.SerializeObject(request.Body, _settings) };
    }
}