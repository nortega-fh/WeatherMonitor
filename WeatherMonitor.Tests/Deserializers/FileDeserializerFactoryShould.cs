using FluentAssertions;
using Moq;
using System.Reflection;
using WeatherMonitor.Deserializers;
using WeatherMonitor.Deserializers.Factory;
using WeatherMonitor.Exceptions;
using Xunit.Sdk;

namespace WeatherMonitor.Tests.Deserializers;

public class FileDeserializerFactoryShould
{
    [Theory]
    [InlineData("test_weather_data.json")]
    [InlineData("test_robot_config.json")]
    public void ReturnJsonDeserializerWhenFileHasJsonExtension(string fileName)
    {
        var sut = new FileDeserializerFactory<It.IsAnyType>();

        var serializerObtained = sut.GetDeserializer(fileName);

        serializerObtained.Should().BeOfType<JsonDeserializer<It.IsAnyType>>();
    }

    [Fact]
    public void ReturnXmlDeserializerWhenFileHasXmlExtension()
    {
        var sut = new FileDeserializerFactory<It.IsAnyType>();

        var serializerObtained = sut.GetDeserializer("text_weather_data.xml");

        serializerObtained.Should().BeOfType<XmlDeserializer<It.IsAnyType>>();
    }

    [Theory]
    [UnsupportedFileExtension]
    public void ThrowFileExtensionExceptionWhenExtensionIsNotSupported(string file)
    {
        var sut = new FileDeserializerFactory<It.IsAnyType>();

        sut.Invoking(sut => sut.GetDeserializer(file)).Should().Throw<FileExtensionException>();
    }

    class UnsupportedFileExtension : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "file.csv" };
            yield return new object[] { "file.txt" };
            yield return new object[] { "file.xslx" };
            yield return new object[] { "file.doc" };
            yield return new object[] { "file.docx" };
        }
    }
}
