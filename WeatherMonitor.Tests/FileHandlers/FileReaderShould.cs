using AutoFixture;
using Moq;
using WeatherMonitor.Bots;
using WeatherMonitor.Deserializers;
using WeatherMonitor.FileHandlers;

namespace WeatherMonitor.Tests.FileHandlers;

public class FileReaderShould
{
    private static readonly Fixture Fixture = new();

    [Fact]
    public void ReadAnExistingFileAndDeserialize()
    {
        var path = Fixture.Create<string>();
        var fileCreator = File.Create(path);
        fileCreator.Close();
        var expectedBot = Fixture.Create<SunBot>();
        var deserializerMoq = new Mock<IDeserializer<IBot>>();
        deserializerMoq.Setup(deserializer => deserializer.Deserialize(It.IsAny<Stream>()))
            .Returns(expectedBot)
            .Verifiable(Times.Once);
        var sut = new FileReader<IBot>(deserializerMoq.Object);

        var obtainedBot = sut.Read(path);

        Assert.Equal(expectedBot, obtainedBot);

        File.Delete(path);
    }

    [Fact]
    public void ThrowWhenFileDoesNotExists()
    {
        var fakeFileName = Fixture.Create<string>();
        var deserializerMoq = new Mock<IDeserializer<IBot>>();

        var sut = new FileReader<IBot>(deserializerMoq.Object);

        Assert.Throws<FileNotFoundException>(() => sut.Read(fakeFileName));
    }
}