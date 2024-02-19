using WeatherMonitor.Deserializers;

namespace WeatherMonitor.FileHandlers;

public class FileReader<T> : IFileReader<T> where T : class
{
    private readonly IDeserializer<T> _deserializer;

    public FileReader(IDeserializer<T> deserializer)
    {
        _deserializer = deserializer;
    }

    public T Read(string fileName)
    {
        using var fileStream = File.OpenRead(fileName);
        return _deserializer.Deserialize(fileStream);
    }
}
