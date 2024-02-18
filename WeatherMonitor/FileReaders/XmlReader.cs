
namespace WeatherMonitor.FileReaders;

public class XmlReader : FileReader
{
    protected override T? Deserialize<T>(FileStream stream) where T : class
    {
        throw new NotImplementedException();
    }
}
