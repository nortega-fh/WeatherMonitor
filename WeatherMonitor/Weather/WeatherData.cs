using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace WeatherMonitor.Weather;

public class WeatherData
{
    public string Location { get; set; } = string.Empty;

    [JsonPropertyName("temperature")]
    [XmlElement("Temperature")]
    public float CentigradesTemperature { get; set; }

    [JsonPropertyName("humidity")]
    [XmlElement("Humidity")]
    public float HumidityPercentage { get; set; }
}
