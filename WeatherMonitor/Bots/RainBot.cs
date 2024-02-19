using System.Text.Json.Serialization;

namespace WeatherMonitor.Bots;

public class RainBot : Bot
{
    [JsonPropertyName("HumidityThreshold")]
    public float HumidityPercentageThreshold { get; set; }
}