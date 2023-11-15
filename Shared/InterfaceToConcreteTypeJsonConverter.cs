using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BomberGopnik.Shared
{
    public class InterfaceToConcreteTypeJsonConverter<TInterface, TConcreteType> : JsonConverter
        where TInterface : class
        where TConcreteType : class, TInterface
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(TInterface));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(TConcreteType));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(TConcreteType));
        }
    }
}
