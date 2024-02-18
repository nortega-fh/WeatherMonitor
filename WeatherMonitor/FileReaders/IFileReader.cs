namespace WeatherMonitor.FileReaders;

public interface IFileReader
{
    public T? Parse<T>(string file) where T : class;
}
