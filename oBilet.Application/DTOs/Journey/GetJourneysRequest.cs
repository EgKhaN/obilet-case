using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Application.DTOs.Journey
{
    public class GetJourneysRequest : BaseRequest<JourneyRequestData>
    {
        public GetJourneysRequest(JourneyRequestData data, string? sessionId = null, string? deviceId = null)
            : base(data, sessionId, deviceId)
        {
        }
        public GetJourneysRequest()
        { }
    }
}
