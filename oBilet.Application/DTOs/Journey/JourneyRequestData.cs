using Newtonsoft.Json;
using oBilet.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Application.DTOs.Journey
{
    public class JourneyRequestData
    {
        [JsonProperty(PropertyName = "origin-id")]
        public long OriginId { get; set; }

        [JsonProperty(PropertyName = "destination-id")]
        public long DestinationId { get; set; }

        [JsonProperty(PropertyName = "departure-date")]
        public string? DepartureDate { get; set; }

        public JourneyRequestData(long originId, long destinationId, DateTime departureDate)
        {
            OriginId = originId;
            DestinationId = destinationId;
            DepartureDate = departureDate.ToString(Consts.ISO8601DateFormat); // ISO 8601 format
        }
    }
}
