using Newtonsoft.Json;

namespace SoundCloudSharp.Api.Models.Converters;

public class StringEnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
    public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString().ToLowerInvariant());
    }

    public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var value = reader.Value as string;
        return Enum.TryParse<T>(value, ignoreCase: true, out var result) ? result : default;
    }
}