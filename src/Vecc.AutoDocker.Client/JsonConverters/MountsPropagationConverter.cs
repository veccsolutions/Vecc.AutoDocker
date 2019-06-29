using System;
using Newtonsoft.Json;
using Vecc.AutoDocker.Client.Docker.Mounts;

namespace Vecc.AutoDocker.Client.JsonConverters
{
    public class MountsPropagationConverter : JsonConverter<Propagation>
    {
        public override Propagation ReadJson(JsonReader reader, Type objectType, Propagation existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            if (!Enum.TryParse<Propagation>(value, out var result))
            {
                return Propagation.Unknown;
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, Propagation value, JsonSerializer serializer)
        {
            switch (value)
            {
                case Propagation.Unknown:
                    writer.WriteValue(string.Empty);
                    break;
                default:
                    writer.WriteValue(value.ToString().ToLower());
                    break;
            }
        }
    }
}
