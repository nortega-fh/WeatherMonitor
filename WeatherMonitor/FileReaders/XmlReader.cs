
using System.Xml.Serialization;

namespace WeatherMonitor.FileReaders;

public class XmlReader : FileReader
{
    protected override T? Deserialize<T>(FileStream stream) where T : class
    {
        var serializer = new XmlSerializer(typeof(T));
        return (T?)serializer.Deserialize(stream);
    }
}
