namespace WeatherMonitor.Exceptions;

public class DeserializeException(string reason) : Exception(reason);
