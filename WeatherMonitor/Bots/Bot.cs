namespace WeatherMonitor.Bots;

public abstract class Bot
{
    public bool Enabled { get; set; }
    public string Message { get; set; } = string.Empty;

    public void Activate()
    {
        var botType = this.GetType().Name;
        Console.WriteLine($"{botType} active!");
        Console.WriteLine($"{botType}: \"{Message}\"");
    }
}
