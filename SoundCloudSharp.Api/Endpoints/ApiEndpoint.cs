using SoundCloudSharp.Api.Http;

namespace SoundCloudSharp.Api.Endpoints;

public abstract class ApiEndpoint(ApiConnector connector)
{
    protected ApiConnector Connector { get; } = connector;
    
    protected static Dictionary<string, string> BuildQuery<T>(T request, string? scalarParamName = null)
    {
        if (request is null)
            return new Dictionary<string, string>();
    
        if (IsScalarType(typeof(T)) && scalarParamName != null)
            return QueryStringBuilder.BuildScalar(scalarParamName, request);
    
        return QueryStringBuilder.Build(request);
    }
    
    private static bool IsScalarType(Type type)
    {
        var underlyingType = Nullable.GetUnderlyingType(type) ?? type;
    
        return underlyingType.IsPrimitive
               || underlyingType == typeof(string)
               || underlyingType == typeof(decimal)
               || underlyingType == typeof(DateTimeOffset)
               || underlyingType == typeof(DateTime)
               || underlyingType.IsEnum
               || typeof(System.Collections.IEnumerable).IsAssignableFrom(underlyingType);
    }
}