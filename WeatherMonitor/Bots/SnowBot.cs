﻿using System.Text.Json.Serialization;
using WeatherMonitor.Weather;

namespace WeatherMonitor.Bots;

public class SnowBot : IBot
{
    public bool Enabled { get; set; }

    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("TemperatureThreshold")]
    public float CentigradesTemperatureThreshold { get; set; }

    public void Activate(WeatherData data)
    {
        if (Enabled && data.CentigradesTemperature < CentigradesTemperatureThreshold)
        {
            Console.WriteLine("SnowBot activated!");
            Console.WriteLine(Message);
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is SnowBot other
            && other.Enabled == Enabled
            && other.Message.Equals(Message)
            && other.CentigradesTemperatureThreshold.Equals(CentigradesTemperatureThreshold);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Enabled, Message, CentigradesTemperatureThreshold);
    }
}
