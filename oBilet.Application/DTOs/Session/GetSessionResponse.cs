using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Application.DTOs.Session
{
    public class GetSessionResponse : BaseResponse<UserSessionData>
    {
        [JsonProperty(PropertyName = "client-request-id")]
        public string? ClientRequestId { get; set; }

        [JsonProperty(PropertyName = "web-correlation-id")]
        public string? WebCorrelationId { get; set; }

        [JsonProperty(PropertyName = "correlation-id")]
        public string? CorrelationId { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public string? Parameters { get; set; }
    }

    public class UserSessionData
    {
        [JsonProperty(PropertyName = "session-id")]
        public string? SessionId { get; set; }

        [JsonProperty(PropertyName = "device-id")]
        public string? DeviceId { get; set; }

        [JsonProperty(PropertyName = "affiliate")]
        public string? Affiliate { get; set; }

        [JsonProperty(PropertyName = "device-type")]
        public long? DeviceType { get; set; }

        [JsonProperty(PropertyName = "device")]
        public string? Device { get; set; }

        [JsonProperty(PropertyName = "ip-country")]
        public string? IpCountry { get; set; }

        [JsonProperty(PropertyName = "clean-session-id")]
        public long? CleanSessionId { get; set; }

        [JsonProperty(PropertyName = "clean-device-id")]
        public long? CleanDeviceId { get; set; }

        [JsonProperty(PropertyName = "ip-address")]
        public string? IpAddress { get; set; }
    }
}
