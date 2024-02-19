namespace WeatherMonitor.Deserializers.Factory;

public interface IFileDeserializerFactory<T> where T : class
{
    IDeserializer<T> GetDeserializer(string fileName);
}