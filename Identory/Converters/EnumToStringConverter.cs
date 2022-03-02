using Newtonsoft.Json;
using System;

namespace Identory.Converters
{
    public class EnumToStringConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            return;
        }
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            return (string)reader.Value;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
