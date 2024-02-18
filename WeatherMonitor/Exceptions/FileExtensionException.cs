namespace WeatherMonitor.Exceptions;

public class FileExtensionException(string fileExtension) : Exception($"Error: file extension {fileExtension} is not supported");
