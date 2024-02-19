namespace WeatherMonitor.Bots.Configuration;

public record BotConfiguration
{
    public RainBot? RainBot { get; set; }
    public SunBot? SunBot { get; set; }
    public SnowBot? SnowBot { get; set; }
}
