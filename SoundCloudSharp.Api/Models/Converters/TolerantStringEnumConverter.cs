using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SoundCloudSharp.Api.Models.Converters;

public class TolerantStringEnumConverter : StringEnumConverter
{
    public override object? ReadJson(
        JsonReader reader,
        Type objectType,
        object? existingValue,
        JsonSerializer serializer)
    {
        var enumType = Nullable.GetUnderlyingType(objectType)
                       ?? objectType;
        try
        {
            return base.ReadJson(
                reader,
                objectType,
                existingValue,
                serializer);
        }
        catch (JsonSerializationException)
            when (enumType.IsEnum)
        {
            if (Nullable.GetUnderlyingType(objectType) is not null)
                return null;

            return Enum.Parse(enumType, "Unknown");
        }
    }
}