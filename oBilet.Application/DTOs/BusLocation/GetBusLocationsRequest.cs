using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Application.DTOs.BusLocation
{
    public class GetBusLocationsRequest : BaseRequest<string>
    {
        public GetBusLocationsRequest() { }
        public GetBusLocationsRequest(string? data = null, string? sessionId = null, string? deviceId = null)
            : base(data, sessionId, deviceId)
        {
        }
    }
}
