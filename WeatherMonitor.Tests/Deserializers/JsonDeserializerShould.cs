using FluentAssertions;
using WeatherMonitor.Bots;
using WeatherMonitor.Bots.Configuration;
using WeatherMonitor.Deserializers;
using WeatherMonitor.Weather;

namespace WeatherMonitor.Tests.Deserializers;

public class JsonDeserializerShould
{
    [Fact]
    public void DeserializeWeatherData()
    {
        using var jsonFile = File.OpenRead("test_weather_data.json");
        var expectedWeatherData = new WeatherData
        {
            Location = "Gasglow",
            CentigradesTemperature = 4.0f,
            HumidityPercentage = 55.0f
        };
        var sut = new JsonDeserializer<WeatherData>();

        var obtainedData = sut.Deserialize(jsonFile);

        obtainedData.Should().Be(expectedWeatherData);
    }

    [Fact]
    public void DeserializeBotConfiguration()
    {
        using var jsonFile = File.OpenRead("test_robot_config.json");
        var rainBot = new RainBot() { Enabled = true, HumidityPercentageThreshold = 80, Message = "It looks like it's about to pour down!" };
        var sunBot = new SunBot() { Enabled = true, CentigradesTemperatureThreshold = 30, Message = "Wow, it's a scorcher out there!" };
        var snowBot = new SnowBot() { Enabled = true, CentigradesTemperatureThreshold = 5, Message = "Brrr, it's getting chilly!" };
        var expectedConfiguration = new BotConfiguration(rainBot, sunBot, snowBot);
        var sut = new JsonDeserializer<BotConfiguration>();

        var obtainedData = sut.Deserialize(jsonFile);

        obtainedData.Should().Be(expectedConfiguration);
    }
}
