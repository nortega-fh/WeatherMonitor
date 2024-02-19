using System.Text.Json.Serialization;

namespace WeatherMonitor.Bots;

public class TemperatureBot : Bot
{
    [JsonPropertyName("TemperatureThreshold")]
    public float CentigradesTemperatureThreshold { get; set; }
}
