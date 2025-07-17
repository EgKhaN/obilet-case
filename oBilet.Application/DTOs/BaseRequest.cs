using Newtonsoft.Json;
using oBilet.Application.DTOs.Session;
using oBilet.Application.Helpers;
using oBilet.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Application.DTOs
{
    public class BaseRequest<T>
    {
        [JsonProperty(PropertyName = "data")]
        public T? Data { get; set; }

        [JsonProperty(PropertyName = "device-session")]
        public DeviceSession? DeviceSession { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string? Date { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string? Language { get; set; }

        public BaseRequest(T? data, string? sessionId = null, string? deviceId = null)
        {
            Data = data;
            DeviceSession = new DeviceSession(sessionId, deviceId);
            Date = DateTime.UtcNow.ToString(Consts.ISO8601DateFormat);
            Language = Request.TrLanguage; // Default language, can be changed as needed
        } 
        
        public BaseRequest(T? data, UserSessionData? userSessionData = null) : this(data, userSessionData?.SessionId, userSessionData?.DeviceId)
        {}
        public BaseRequest()
        {
        }
    }

    public class DeviceSession
    {
        [JsonProperty(PropertyName = "session-id")]
        public string? SessionId { get; set; }

        [JsonProperty(PropertyName = "device-id")]
        public string? DeviceId { get; set; }

        public DeviceSession(string? sessionId, string? deviceId)
        {
            SessionId = sessionId;
            DeviceId = deviceId;
        }
        
        public DeviceSession(UserSessionData userSessionData)
        {
            SessionId = userSessionData.SessionId;
            DeviceId = userSessionData.DeviceId;
        }
    }
}
