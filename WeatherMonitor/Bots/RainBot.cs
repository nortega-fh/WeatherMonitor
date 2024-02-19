using System.Text.Json.Serialization;
using WeatherMonitor.Weather;

namespace WeatherMonitor.Bots;

public class RainBot : IBot
{
    public bool Enabled { get; set; }

    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("HumidityThreshold")]
    public float HumidityPercentageThreshold { get; set; }

    public void Activate(WeatherData data)
    {
        if (Enabled && data.HumidityPercentage > HumidityPercentageThreshold)
        {
            Console.WriteLine("RainBot activated!");
            Console.WriteLine(Message);
        }
    }
}