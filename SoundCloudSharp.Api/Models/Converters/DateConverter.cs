using System.Globalization;
using Newtonsoft.Json;

namespace SoundCloudSharp.Api.Models.Converters;

public class DateConverter : JsonConverter<DateTimeOffset>
{
    private const string Format = "yyyy/MM/dd HH:mm:ss zzz";

    public override void WriteJson(JsonWriter writer, DateTimeOffset value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString(Format, CultureInfo.InvariantCulture));
    }

    public override DateTimeOffset ReadJson(JsonReader reader, Type objectType, DateTimeOffset existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        if (reader.TokenType != JsonToken.String)
            throw new JsonSerializationException(
                $"Expected string for date, got {reader.TokenType}.");
        
        var value = (string)reader.Value!;
        
        return DateTimeOffset.ParseExact(
            value,
            Format,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None);
    }
}