using System.Text.Json.Serialization;
using WeatherMonitor.Weather;

namespace WeatherMonitor.Bots;

public class SunBot : IBot
{
    public bool Enabled { get; set; }

    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("TemperatureThreshold")]
    public float CentigradesTemperatureThreshold { get; set; }

    public void Activate(WeatherData data)
    {
        throw new NotImplementedException();
    }
}
