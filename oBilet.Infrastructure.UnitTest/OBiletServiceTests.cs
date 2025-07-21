using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using oBilet.Application.Abstractions;
using oBilet.Application.DTOs;
using oBilet.Application.DTOs.BusLocation;
using oBilet.Infrastructure.Common;
using oBilet.Infrastructure.OBiletAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Infrastructure.UnitTest
{
    public class OBiletServiceTests
    {
        private OBiletService _oBiletService;
        private readonly Mock<IApiService> _apiServiceMock;

        public OBiletServiceTests()
        {
            _apiServiceMock = new Mock<IApiService>();
            

        }

        [Fact]
        public async void GetBusLocationsAsync_ReturnsBusLocations()
        {
            // Arrange
            BusLocationsResponseData busLocationsResponseData = new BusLocationsResponseData
            {
                ID = 1,
                Name = "Test Location"
            };
            GetBusLocationsResponse getBusLocationsResponse = new GetBusLocationsResponse
            {
                Data = new List<BusLocationsResponseData> { busLocationsResponseData }
            };
            _apiServiceMock.Setup(_ => _.PostAsync<GetBusLocationsResponse, string>(It.IsAny<string>(), It.IsAny<BaseRequest<string>>()))
                .ReturnsAsync(getBusLocationsResponse);

            _oBiletService = new OBiletService(
                Mock.Of<ILogger<OBiletService>>(),
                Mock.Of<ISessionService>(),
                _apiServiceMock.Object
            );
            // Act
            var locations = await _oBiletService.GetBusLocationsAsync();

            // Assert
            Assert.Single(locations.Value);
            Assert.Equal(1, locations.Value.FirstOrDefault()?.ID);
        }

    }
}
