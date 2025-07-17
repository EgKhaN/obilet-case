using Newtonsoft.Json;
using static oBilet.Core.Common.Request;

namespace oBilet.Application.DTOs.Session
{
    public class GetSessionRequest
    {
        [JsonProperty(PropertyName = "type")]
        public int? Type { get; set; }
        [JsonProperty(PropertyName = "connection")]
        public Connection? Connection { get; set; }
        [JsonProperty(PropertyName = "browser")]
        public Browser? Browser { get; set; }

        public GetSessionRequest(string ipAddress, string port, string browserName, string version)
        {
            Type = (int)RequestType.Default;
            Connection = new Connection(ipAddress, port);
            Browser = new Browser(browserName, version);
        }
    }

    public class Connection
    {
        [JsonProperty(PropertyName = "ip-address")]
        public string? IpAddress { get; set; }
        [JsonProperty(PropertyName = "port")]

        public string? Port { get; set; }

        public Connection(string ipAdress, string port)
        {
            IpAddress = ipAdress;
            Port = port;
        }
    }

    public class Browser
    {
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }
        [JsonProperty(PropertyName = "version")]
        public string? Version { get; set; }

        public Browser()
        { }
        public Browser(string browserName, string version)
        {
            Name = browserName;
            Version = version;
        }
    }
}
