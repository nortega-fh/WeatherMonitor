using WeatherMonitor.Weather;

namespace WeatherMonitor.Bots;

public class BotActivator : IBotActivator
{
    private readonly IEnumerable<IBot> _bots;

    public BotActivator(IEnumerable<IBot> bots)
    {
        _bots = bots;
    }

    public void ActivateBots(WeatherData data)
    {
        foreach (var bot in _bots)
        {
            bot.Activate(data);
        }
    }
}
