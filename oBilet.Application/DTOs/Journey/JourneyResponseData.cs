using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Application.DTOs.Journey
{
    public class JourneyResponseData
    {
        [JsonProperty(PropertyName = "id")]
        public long ID { get; set; }

        [JsonProperty(PropertyName = "journey")]
        public JourneyData? Journey { get; set; } 
        
        [JsonProperty(PropertyName = "origin-location")]
        public string? OriginLocation { get; set; }
        
        [JsonProperty(PropertyName = "destination-location")]
        public string? DestinationLocation { get; set; }
    }

    public class JourneyData
    {
        [JsonProperty(PropertyName = "origin")]
        public string? Origin { get; set; }

        [JsonProperty(PropertyName = "destination")]
        public string? Destination { get; set; }

        [JsonProperty(PropertyName = "departure")]
        public DateTime? Departure { get; set; }

        [JsonProperty(PropertyName = "arrival")]
        public DateTime? Arrival { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string? Currency { get; set; }

        [JsonProperty("original-price")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty(PropertyName = "internet-price")]
        public decimal InternetPrice { get; set; }
    }
}
