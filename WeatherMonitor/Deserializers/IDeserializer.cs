namespace WeatherMonitor.Deserializers;

public interface IDeserializer<T> where T : class
{
    T Deserialize(Stream stream);
}
