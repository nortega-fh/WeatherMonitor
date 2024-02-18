namespace WeatherMonitor.FileReaders;

public interface IFileReaderFactory
{
    IFileReader GetReaderForFile(string file);
}