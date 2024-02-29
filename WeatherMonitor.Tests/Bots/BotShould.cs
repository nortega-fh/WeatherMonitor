using FluentAssertions;
using WeatherMonitor.Bots;
using WeatherMonitor.Weather;

namespace WeatherMonitor.Tests.Bots;

public class BotShould
{
    private static readonly WeatherData WeatherData = new()
    {
        Location = "Test",
        HumidityPercentage = 1,
        CentigradesTemperature = 1
    };

    [Theory]
    [DisabledBots]
    public void NotPrintToConsoleWhenNotEnabled(IBot bot)
    {
        var sut = bot;

        var printedMessage = new StringWriter();
        Console.SetOut(printedMessage);

        sut.Activate(WeatherData);

        var output = printedMessage.ToString();
        output.Should().BeEmpty();
    }

    [Theory]
    [EnabledOutsideThresholdBots]
    public void NotPrintToConsoleWhenOutsideTreshold(IBot bot)
    {
        var sut = bot;

        var printedMessage = new StringWriter();
        Console.SetOut(printedMessage);

        sut.Activate(WeatherData);

        var output = printedMessage.ToString();
        output.Should().BeEmpty();
    }

    [Theory]
    [EnabledAndInThresholdBots]
    public void PrintToConsoleWhenEnabledAndInThreshold(IBot bot)
    {
        var sut = bot;

        var printedMessage = new StringWriter();
        Console.SetOut(printedMessage);

        sut.Activate(WeatherData);

        var output = printedMessage.ToString();
        output.Should().NotBeNullOrWhiteSpace();
    }
}
