
using System.Text.Json;
using WeatherMonitor.Exceptions;

namespace WeatherMonitor.Deserializers;

public class JsonDeserializer<T> : IDeserializer<T> where T : class
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public T Deserialize(Stream stream)
    {
        return JsonSerializer.Deserialize<T>(stream, Options)
            ?? throw new DeserializeException($"Could not deserialize {typeof(T).Name} from json: verify structure and properties");
    }
}
