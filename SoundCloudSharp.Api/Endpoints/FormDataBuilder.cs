using System.Globalization;
using System.Reflection;
using SoundCloudSharp.Api.Models.Request;

namespace SoundCloudSharp.Api.Endpoints;

public static class FormDataBuilder
{
    public static MultipartFormDataContent Build<T>(T request)
    {
        var form = new MultipartFormDataContent();

        foreach (var prop in typeof(T).GetProperties())
        {
            var attr = prop.GetCustomAttribute<FormFieldAttribute>();
            if (attr is null) continue;

            var value = prop.GetValue(request);
            if (value is null) continue;

            form.Add(new StringContent(FormatValue(value)), attr.Name);
        }

        return form;
    }

    private static string FormatValue(object value) => value switch
    {
        Enum e => e.ToString().ToLowerInvariant(),
        bool b => b.ToString().ToLowerInvariant(),
        _ => Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty
    };
}