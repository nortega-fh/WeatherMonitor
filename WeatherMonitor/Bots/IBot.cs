using WeatherMonitor.Weather;

namespace WeatherMonitor.Bots;

public interface IBot
{
    void Activate(WeatherData data);
}
