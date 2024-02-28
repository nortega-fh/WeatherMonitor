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

    public override bool Equals(object? obj) => obj is WeatherData data && data.Location.Equals(Location)
            && data.CentigradesTemperature == CentigradesTemperature
            && data.HumidityPercentage == HumidityPercentage;

    public override int GetHashCode()
    {
        return HashCode.Combine(Location, CentigradesTemperature, HumidityPercentage);
    }
}
