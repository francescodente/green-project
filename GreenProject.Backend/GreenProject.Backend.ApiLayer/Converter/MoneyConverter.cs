using GreenProject.Backend.Entities.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Converter
{
    public class MoneyConverter : JsonConverter<Money>
    {
        public override Money ReadJson(JsonReader reader, Type objectType, Money existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return reader.TokenType switch
            {
                JsonToken.Integer => (long)reader.Value,
                JsonToken.Float => (decimal)reader.Value,
                _ => 0
            };
        }

        public override void WriteJson(JsonWriter writer, Money value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }
    }
}
