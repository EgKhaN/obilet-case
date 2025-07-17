using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Application.Helpers
{
    public static class BusLocationError
    {
        public static Error NoLocationFound() => Error.Failure(
       "BusLocation.NoLocationFound",
       "No bus locations found.");
    }
}
