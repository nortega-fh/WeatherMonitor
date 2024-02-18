
using System.Text.Json;

namespace WeatherMonitor.FileReaders;

public class JsonReader : FileReader
{
    private static readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    protected override T? Deserialize<T>(FileStream stream) where T : class
    {
        return JsonSerializer.Deserialize<T>(stream, _options);
    }
}
