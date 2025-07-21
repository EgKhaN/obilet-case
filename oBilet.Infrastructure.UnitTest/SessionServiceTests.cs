using Microsoft.AspNetCore.Http;
using Moq;
using oBilet.Application.Abstractions;
using oBilet.Infrastructure.OBiletAPI;
namespace oBilet.Infrastructure.UnitTest
{
    public class SessionServiceTests
    {
        private SessionService _sessionService;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private readonly Mock<IBrowserHelper> _browserHelperMock;

        private readonly string localIpAdress = "127.0.0.1";
        private readonly int portNumber = 5701;
        public SessionServiceTests()
        {
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            _browserHelperMock = new Mock<IBrowserHelper>();


        }

        [Fact]
        public void GetUserIP_ReturnsLocalIpAdress()
        {
            // Arrange
            _httpContextAccessorMock.Setup(_ => _.HttpContext.Connection.RemoteIpAddress).Returns(System.Net.IPAddress.Parse(localIpAdress)); _sessionService = new SessionService(_httpContextAccessorMock.Object, _browserHelperMock.Object);
            // Act
            string userIp = _sessionService.GetUserIP();

            // Assert
            Assert.Equal(localIpAdress, userIp);
        }
        
        [Fact]
        public void GetPortNumber_ReturnsPortNumber()
        {
            // Arrange
            _httpContextAccessorMock.Setup(_ => _.HttpContext.Request.Host).Returns( new HostString("host", portNumber)); 
            _sessionService = new SessionService(_httpContextAccessorMock.Object, _browserHelperMock.Object);
            // Act
            string result = _sessionService.GetPortNumber();

            // Assert
            Assert.Equal(portNumber.ToString(), result);
        }
    }
}