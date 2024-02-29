using System.Reflection;
using WeatherMonitor.Bots;
using Xunit.Sdk;

namespace WeatherMonitor.Tests.Bots;

internal class DisabledBotsAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { new RainBot() { Enabled = false } };
        yield return new object[] { new SunBot() { Enabled = false } };
        yield return new object[] { new SnowBot() { Enabled = false } };
    }
}
