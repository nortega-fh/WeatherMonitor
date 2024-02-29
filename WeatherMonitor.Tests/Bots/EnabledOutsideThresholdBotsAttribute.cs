using System.Reflection;
using WeatherMonitor.Bots;
using Xunit.Sdk;

namespace WeatherMonitor.Tests.Bots;

public class EnabledOutsideThresholdBotsAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { new RainBot() { Enabled = true, HumidityPercentageThreshold = 2 } };
        yield return new object[] { new SunBot() { Enabled = true, CentigradesTemperatureThreshold = 2 } };
        yield return new object[] { new SnowBot() { Enabled = true } };
    }
}
