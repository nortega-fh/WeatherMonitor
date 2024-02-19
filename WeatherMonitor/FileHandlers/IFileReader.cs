namespace WeatherMonitor.FileHandlers;

public interface IFileReader<T> where T : class
{
    T Read(string fileName);
}
