namespace WeatherMonitor.Bots.Configuration;

public interface IBotConfigReader
{
    BotConfiguration? GetBotsConfiguration();
}