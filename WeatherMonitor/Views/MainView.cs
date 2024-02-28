using WeatherMonitor.Bots;
using WeatherMonitor.Bots.Configuration;
using WeatherMonitor.Deserializers;
using WeatherMonitor.Deserializers.Factory;
using WeatherMonitor.FileHandlers;
using WeatherMonitor.Weather;

namespace WeatherMonitor.Views;

public class MainView
{
    public static void Execute()
    {
        var botActivator = LoadBotsConfiguration();
        while (true)
        {
            var weatherData = GetWeatherData();
            if (weatherData is null)
            {
                continue;
            }
            botActivator.ActivateBots(weatherData);
        }
    }

    private static BotActivator LoadBotsConfiguration()
    {
        var directoryRoot = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;
        var botConfigFile = Path.Combine(directoryRoot, "Config", "robots.json");

        var jsonBotReader = new JsonDeserializer<BotConfiguration>();
        var botFileReader = new FileReader<BotConfiguration>(jsonBotReader);
        var (rainBot, sunBot, snowBot) = botFileReader.Read(botConfigFile);

        return new BotActivator([rainBot, sunBot, snowBot]);
    }

    private static WeatherData? GetWeatherData()
    {
        Console.WriteLine("Please enter the weather data (file name):");
        var fileName = Console.ReadLine();

        while (fileName is null or "")
        {
            Console.WriteLine("Invalid input. Please try again");
            fileName = Console.ReadLine();
            continue;
        }

        var weatherDeserializerFactory = new FileDeserializerFactory<WeatherData>();
        var weatherReader = new FileReader<WeatherData>(weatherDeserializerFactory.GetDeserializer(fileName));
        try
        {
            var directoryRoot = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;
            var weatherDataFile = Path.Combine(directoryRoot, "Data", fileName);
            return weatherReader.Read(weatherDataFile);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return null;
    }
}
