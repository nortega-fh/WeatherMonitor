using WeatherMonitor.FileReaders;

namespace WeatherMonitor.Bots.Configuration;

public class BotConfigReader(IFileReader reader) : IBotConfigReader
{
    private static readonly string _configFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName,
        "Config", "robots.json");

    private readonly IFileReader _configFileReader = reader;

    public BotConfiguration? GetBotsConfiguration() => _configFileReader.Parse<BotConfiguration>(_configFilePath);
}
