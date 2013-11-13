using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itBit.Net.Http.Converters {
    public sealed class ReadOnlyCollectionConverter : JsonConverter {
        private static readonly Type[] supportedTypes = new[] { typeof(IReadOnlyList<>), typeof(IReadOnlyCollection<>), typeof(ReadOnlyCollection<>) };

        public override bool CanConvert(Type objectType) {
            if(!objectType.IsGenericType)
                return false;
            var genType = objectType.GetGenericTypeDefinition();
            return supportedTypes.Any(type => type.IsAssignableFrom(genType));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if(reader.TokenType == JsonToken.Null)
                return null;
            var typeArgs = objectType.GetGenericArguments();
            var list = serializer.Deserialize(reader, typeof(List<>).MakeGenericType(typeArgs));
            var wrapperType = typeof(ReadOnlyCollection<>).MakeGenericType(typeArgs);
            return Activator.CreateInstance(wrapperType, list);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            writer.WriteStartArray();
            foreach(var entry in (ICollection)value)
                serializer.Serialize(writer, entry);
            writer.WriteEndArray();
        }
    }
}
