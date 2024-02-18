namespace WeatherMonitor.Weather;

public interface IWeatherReader
{
    public WeatherData? Read(string fileName);
}
