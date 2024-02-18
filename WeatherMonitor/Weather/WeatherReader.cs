using WeatherMonitor.FileReaders;

namespace WeatherMonitor.Weather;

public class WeatherReader : IWeatherReader
{
    private readonly IFileReaderFactory _readerFactory;

    public WeatherReader(IFileReaderFactory readerFactory)
    {
        _readerFactory = readerFactory;
    }

    public WeatherData? Read(string fileName)
    {
        var fileReader = _readerFactory.GetReaderForFile(fileName);
        return fileReader.Parse<WeatherData>(fileName);
    }
}
