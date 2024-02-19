using WeatherMonitor.Exceptions;

namespace WeatherMonitor.Deserializers.Factory;

public class FileDeserializerFactory<T> : IFileDeserializerFactory<T> where T : class
{
    public IDeserializer<T> GetDeserializer(string fileName)
    {
        string fileExtension = Path.GetExtension(fileName);
        return fileExtension switch
        {
            ".json" => new JsonDeserializer<T>(),
            ".xml" => new XmlDeserializer<T>(),
            _ => throw new FileExtensionException(fileExtension)
        };
    }
}
