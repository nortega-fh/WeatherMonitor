using AutoFixture;
using Moq;
using WeatherMonitor.Bots;
using WeatherMonitor.Weather;

namespace WeatherMonitor.Tests.Bots;

public class BotActivatorShould
{

    [Fact]
    public void ActivateBotsLoaded()
    {
        var fixture = new Fixture();
        var weatherData = fixture.Create<WeatherData>();
        var bot = new Mock<IBot>();
        var listOfBots = new List<IBot>() { bot.Object };

        var sut = new BotActivator(listOfBots);

        sut.ActivateBots(weatherData);

        bot.Verify(bot => bot.Activate(weatherData), Times.Once);
    }
}
