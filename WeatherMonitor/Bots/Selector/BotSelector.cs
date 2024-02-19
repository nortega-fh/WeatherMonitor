using WeatherMonitor.Bots.Configuration;
using WeatherMonitor.Weather;

namespace WeatherMonitor.Bots.Selector;

public class BotSelector(IBotConfigReader botConfigReader) : IBotSelector
{
    private readonly IBotConfigReader _botConfigReader = botConfigReader;
    private RainBot _rainBot = new();
    private SunBot _sunBot = new();
    private SnowBot _snowBot = new();

    public IEnumerable<Bot> GetBotsForWeatherData(WeatherData data)
    {
        SetBotsFromConfiguration();
        return GetEnabledBots().Where(bot => IsWeatherDataExceedingTresholds(data, bot));
    }

    private void SetBotsFromConfiguration()
    {
        var botConfig = _botConfigReader.GetBotsConfiguration();
        _rainBot = botConfig?.RainBot ?? _rainBot;
        _sunBot = (SunBot?)botConfig?.SunBot ?? _sunBot;
        _snowBot = (SnowBot?)botConfig?.SnowBot ?? _snowBot;
    }

    private IEnumerable<Bot> GetEnabledBots() => new Bot[] { _rainBot, _sunBot, _snowBot }.Where(bot => bot.Enabled);

    private static bool IsWeatherDataExceedingTresholds(WeatherData data, Bot bot)
        => (bot is RainBot rainBot && data.HumidityPercentage > rainBot.HumidityPercentageThreshold)
        || (bot is SunBot sunBot && data.CentigradesTemperature > sunBot.CentigradesTemperatureThreshold)
        || (bot is SnowBot snowBot && data.CentigradesTemperature < snowBot.CentigradesTemperatureThreshold);

}
