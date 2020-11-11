using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace RPPS_lab1._1
{
    public class XMLSerializer : ISerializer
    {
        private readonly ConcurrentDictionary<Type, XmlSerializer> Serializers = new ConcurrentDictionary<Type, XmlSerializer>();
        public T Deserialize<T>(string obj)
        {
            var type = typeof(T);
            var serializer = Serializers.GetOrAdd(type, type => new XmlSerializer(type));
            using (var reader = new StringReader(obj))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public string Serialize<T>(T obj)
        {
            var type = typeof(T);
            var serializer = Serializers.GetOrAdd(type, type => new XmlSerializer(type));
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }
    }
}
