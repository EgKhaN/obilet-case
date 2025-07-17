using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Infrastructure.Common
{
    public static class Endpoints
    {
        public const string APIBasePath = "/api";
        public const string GetSessionPath = APIBasePath + "/client/getsession";
        public const string GetBusLocationsPath = APIBasePath + "/location/getbuslocations";
        public const string GetJourneysPath = APIBasePath + "/journey/getbusjourneys";
    }
}
