using FluentAssertions;
using WeatherMonitor.Deserializers;
using WeatherMonitor.Weather;

namespace WeatherMonitor.Tests.Deserializers;

public class XmlDeserializerShould
{
    [Fact]
    public void DeserializeWeatherData()
    {
        using var xmlFile = File.OpenRead("test_weather_data.xml");
        var expectedWeatherData = new WeatherData
        {
            Location = "Nassau",
            CentigradesTemperature = 36.0f,
            HumidityPercentage = 75.0f
        };
        var sut = new XmlDeserializer<WeatherData>();

        var obtainedData = sut.Deserialize(xmlFile);

        obtainedData.Should().Be(expectedWeatherData);
    }
}
