var directoryRoot = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;
var dataDirectory = Path.Combine(directoryRoot, "Data");
var configDirectory = Path.Combine(directoryRoot, "Config");

