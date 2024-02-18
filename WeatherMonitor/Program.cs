using WeatherMonitor.FileReaders;
using WeatherMonitor.Weather;

FileReaderFactory factory = new();
WeatherReader reader = new(factory);

var directoryRoot = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;
