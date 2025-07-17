using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using oBilet.Application.Abstractions;
using oBilet.Application.DTOs.BusLocation;
using oBilet.Application.DTOs.Journey;
using oBilet.Application.Helpers;
using oBilet.Infrastructure.Common;
using oBilet.Infrastructure.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Infrastructure.OBiletAPI
{
    public class OBiletService : IOBiletService
    {
        private readonly ILogger<OBiletService> _logger;
        private readonly ISessionService _sessionService;
        private readonly IApiService _apiService;

        public OBiletService(ILogger<OBiletService> logger, ISessionService sessionService, IApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
            _sessionService = sessionService;
        }

        public async Task<Result<List<BusLocationsResponseData>>> GetBusLocationsAsync(string? data = null)
        {
            List<BusLocationsResponseData>? locations = new List<BusLocationsResponseData>();
            GetBusLocationsRequest getAllLocationsRequest = new GetBusLocationsRequest(data);

            GetBusLocationsResponse? response = await _apiService.PostAsync<GetBusLocationsResponse, string>(Endpoints.GetBusLocationsPath, getAllLocationsRequest);

            if (response != null)
                locations = response?.Data;
            if(locations == null || !locations.Any())
                return Result.Failure<List<BusLocationsResponseData>>(BusLocationError.NoLocationFound());

            return locations;
        }

        public async Task<List<JourneyResponseData>?>? GetJourneysAsync(int origin, int destination, DateTime departureDate)
        {
            List<JourneyResponseData>? journeys = new List<JourneyResponseData>();
            JourneyRequestData journeyRequestData = new JourneyRequestData(origin, destination, departureDate);
            GetJourneysRequest getAllJourneysRequest = new GetJourneysRequest(journeyRequestData);

            GetJourneysResponse? response = await _apiService.PostAsync<GetJourneysResponse, JourneyRequestData>(Endpoints.GetJourneysPath, getAllJourneysRequest);

            if (response != null)
                journeys = response?.Data?.OrderBy(q=>q.Journey?.Departure).ToList();

            return journeys;
        }
    }
}
