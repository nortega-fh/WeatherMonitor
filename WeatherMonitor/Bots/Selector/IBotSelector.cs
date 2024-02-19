using WeatherMonitor.Weather;

namespace WeatherMonitor.Bots.Selector;

public interface IBotSelector
{
    IEnumerable<Bot> GetBotsForWeatherData(WeatherData data);
}