namespace WeatherMonitor.Bots.Configuration;

public class BotConfiguration
{
    public RainBot? RainBot { get; set; }
    public TemperatureBot? SunBot { get; set; }
    public TemperatureBot? SnowBot { get; set; }
}
