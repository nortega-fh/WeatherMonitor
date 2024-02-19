using WeatherMonitor.Weather;

namespace WeatherMonitor.Bots;

public interface IBotActivator
{
    void ActivateBots(WeatherData data);
}