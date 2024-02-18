using WeatherMonitor.Exceptions;

namespace WeatherMonitor.FileReaders;

public class FileReaderFactory : IFileReaderFactory
{
    public IFileReader GetReaderForFile(string file)
    {
        string fileExtension = Path.GetExtension(file);
        return fileExtension switch
        {
            ".json" => new JsonReader(),
            ".xml" => new XmlReader(),
            _ => throw new FileExtensionException(fileExtension)
        };
    }
}
