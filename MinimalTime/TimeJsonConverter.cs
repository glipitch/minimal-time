using System.Text.Json;
using System.Text.Json.Serialization;

namespace MinimalTime;

public class TimeJsonConverter : JsonConverter<Time>
{
    public override Time Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var content = reader.GetString();

        return Time.Parse(content!);
    }

    public override void Write(Utf8JsonWriter writer, Time time, JsonSerializerOptions options)
    {
        writer.WriteStringValue(time.ToString());
    }
}