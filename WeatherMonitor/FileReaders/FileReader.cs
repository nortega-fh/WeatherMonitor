namespace WeatherMonitor.FileReaders;

public abstract class FileReader : IFileReader
{
    public T? Parse<T>(string file) where T : class
    {
        using var fileStream = File.OpenRead(file);
        return Deserialize<T>(fileStream);
    }

    protected abstract T? Deserialize<T>(FileStream stream) where T : class;
}
