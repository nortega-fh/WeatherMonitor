using System.Reflection;
using WeatherMonitor.Bots;
using Xunit.Sdk;

namespace WeatherMonitor.Tests.Bots;

public class EnabledAndInThresholdBotsAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { new RainBot() { Enabled = true } };
        yield return new object[] { new SunBot() { Enabled = true } };
        yield return new object[] { new SnowBot() { Enabled = true, CentigradesTemperatureThreshold = 2 } };
    }
}
