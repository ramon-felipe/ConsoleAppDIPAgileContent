using CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.FormatLog;
using CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.Persistance;
using CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.RestRequest;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;


namespace CadidateTesting.RamonFelipeAlvesDeArrudaSilva.Tests
{
    public class UnitTests
    {
        private readonly Mock<IFilePersistance> _filePersistanceMock;
        private readonly Mock<IHttpRequest> _httpRequestMock;
        private readonly Mock<ILogFormat> _logFormatMock;
        private readonly ILogFormat _logFormat;
        private readonly string Uri = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";

        public UnitTests()
        {
            _filePersistanceMock = new Mock<IFilePersistance>();
            _logFormatMock = new Mock<ILogFormat>();
            _logFormat = new LogFormat(_filePersistanceMock.Object);
        }

        [Fact(DisplayName = "LogFormat Should Throw an Exception")]
        [Trait("LogFormat", "Get")]
        public async Task LogFormatMock_Should_ThrowAnException()
        {

            // Arrange
            _logFormatMock.Setup(l => l.FormatLog(It.IsAny<string>())).Throws<Exception>();

            //Act

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _logFormatMock.Object.FormatLog(""));

        }

        [Fact(DisplayName = "EmptyContent Should ThrowAnException")]
        [Trait("LogFormat", "Get")]
        public async Task EmptyContent_Should_ThrowAnException()
        {

            // Arrange
            _filePersistanceMock.Setup(f => f.GetLogContentAsList(It.IsAny<string>()))
                                .ReturnsAsync(new List<string>() { "" })
                ;

            //Act


            //Assert
            await Assert.ThrowsAsync<Exception>(() => _logFormat.FormatLog(Uri));
        }

        [Fact(DisplayName = "Incorrect Content Should ThrowAnException")]
        [Trait("LogFormat", "Get")]
        public async Task IncorrectContent_Should_ThrowAnException()
        {

            // Arrange
            _filePersistanceMock.Setup(f => f.GetLogContentAsList(It.IsAny<string>()))
                                .ReturnsAsync(new List<string>() { "AA|BB|CC|DD|EE|FF" })
                ;

            //Act

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _logFormat.FormatLog(Uri));
        }

        [Fact(DisplayName = "Correct Content Should ThrowAnException")]
        [Trait("LogFormat", "Get")]
        public async Task CorrectContent_Should_ThrowAnException()
        {

            // Arrange
            _filePersistanceMock.Setup(f => f.GetLogContentAsList(It.IsAny<string>()))
                                .ReturnsAsync(new List<string>() { "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2" })
                ;

            //Act
            var result = await _logFormat.FormatLog(Uri);

            //Assert
            Assert.Equal("\"Minha CDN\" GET 200 /robots.txt 100 312 HIT", result.First());
        }
    }
}
