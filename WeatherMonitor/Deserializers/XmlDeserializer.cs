
using System.Xml.Serialization;
using WeatherMonitor.Exceptions;

namespace WeatherMonitor.Deserializers;

public class XmlDeserializer<T> : IDeserializer<T> where T : class
{
    public T Deserialize(Stream stream)
    {
        var serializer = new XmlSerializer(typeof(T));
        return (T?)serializer.Deserialize(stream)
            ?? throw new DeserializeException($"Could not deserialize {typeof(T).Name} from XML: verify elements and structure");
    }
}
