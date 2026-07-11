using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SoundCloudSharp.Api.Models.Response;

namespace SoundCloudSharp.Api.Models.Converters;

public class ActivityConverter : JsonConverter<Activity>
{
    public override void WriteJson(JsonWriter writer, Activity? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }

    public override Activity? ReadJson(JsonReader reader, Type objectType, Activity? existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        var jObject = JObject.Load(reader);
        var type = jObject["type"]?.Value<string>() ?? "track";

        Activity activity = type switch
        {
            "track" or "track:repost" => new TrackActivity
            {
                Origin = jObject["origin"]!.ToObject<Track>(serializer)!,
            },
            "playlist" or "playlist:repost" => new PlaylistActivity
            {
                Origin = jObject["origin"]!.ToObject<Playlist>(serializer)!
            }
        };
        
        activity = activity with {Type  = type};
        serializer.Populate(jObject.CreateReader(), activity);
        return activity;
    }
}