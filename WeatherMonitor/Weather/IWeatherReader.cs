using WeatherMonitor.Weather;

namespace WeatherMonitor.weather;

public interface IWeatherReader
{
    public CityWeather Read(string fileName);
}
