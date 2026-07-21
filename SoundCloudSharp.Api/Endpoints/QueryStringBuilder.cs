using System.Globalization;
using System.Reflection;
using SoundCloudSharp.Api.Models.Request;
using SoundCloudSharp.Api.Models.Request.Paging;

namespace SoundCloudSharp.Api.Endpoints;

public static class QueryStringBuilder
{
    public static Dictionary<string, string> Build<T>(T request)
    {
        var query = new Dictionary<string, string>();

        Populate(query, request);

        return query;
    }

    public static Dictionary<string, string> BuildScalar(string name, object? value)
    {
        var query = new Dictionary<string, string>();
        if (value is not null)
            AddScalar(query, name, value);
        return query;
    }

    public static void AddScalar(Dictionary<string,string> query, string name, object? value)
    {
        if (value is null) return;
        query.Add(name, FormatValue(value));
    }
    
    private static void Populate(Dictionary<string, string> query, object? request)
    {
        if (request is null) return;

        foreach (var prop in request.GetType().GetProperties())
        {
            var value = prop.GetValue(request);
            if (value is null) continue;
            
            var paramAttr = prop.GetCustomAttribute<QueryParamAttribute>();
            var rangeAttr = prop.GetCustomAttribute<QueryParamRangeAttribute>();

            if (paramAttr is not null)
            {
                query[paramAttr.Name] = FormatValue(value);
            }
            else if (rangeAttr is not null)
            {
                AppendRange(query, rangeAttr.Name, value);
            }
            else if (value is IQueryParameterContainer)
            {
                Populate(query, value);
            }
        }
    }
    
    private static bool IsNestedRequest(Type type) => typeof(IQueryParameterContainer).IsAssignableFrom(type);

    private static void AppendRange(Dictionary<string, string> query, string paramName, object rangeFilter)
    {
        var type = rangeFilter.GetType();
        var from = type.GetProperty("From")!.GetValue(rangeFilter);
        var to = type.GetProperty("To")!.GetValue(rangeFilter);

        if (from is not null)
            query[$"{paramName}[from]"] = FormatValue(from);

        if (to is not null)
            query[$"{paramName}[to]"] = FormatValue(to);
    }
    
    private static string FormatValue(object value) => value switch
    {
        Enum e => e.ToString().ToLowerInvariant(),
        bool b => b.ToString().ToLowerInvariant(),
        IEnumerable<Enum> enumList => string.Join(",", enumList.Select(e => e.ToString().ToLowerInvariant())),
        DateTimeOffset d => d.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
        IEnumerable<string> stringList => string.Join(",", stringList),
        _ => Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty
    };
}