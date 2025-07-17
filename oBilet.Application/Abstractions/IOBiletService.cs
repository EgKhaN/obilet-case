using oBilet.Application.DTOs.BusLocation;
using oBilet.Application.DTOs.Journey;
using oBilet.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Application.Abstractions
{
    public interface IOBiletService
    {
        Task<Result<List<BusLocationsResponseData>>> GetBusLocationsAsync(string? data = null);
        Task<List<JourneyResponseData>?>? GetJourneysAsync(int origin, int destination, DateTime departureDate);
    }
}
