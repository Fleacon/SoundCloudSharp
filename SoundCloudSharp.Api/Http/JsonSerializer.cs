using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
                new DateConverter(),
                new TolerantStringEnumConverter()
            },
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            },
            NullValueHandling = NullValueHandling.Ignore,
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

    public Request SerializeBody(Request request)
    {
        var body = request.Body;
        var serializedBody = body switch
        {
            null or string or Stream or HttpContent => body,
            _ => JsonConvert.SerializeObject(body, _settings)
        };
        
        return request with { Body = serializedBody };
    }
}