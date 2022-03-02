using Identory.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Identory.Models
{
    [Serializable]
    public sealed class Proxy
    {
        public Proxy()
        {

        }

        public Proxy(ProxyType proxyType, string proxyHost, string proxyPort)
        {
            ProxyType = proxyType;
            ProxyHost = proxyHost;
            ProxyPort = proxyPort;
        }

        public Proxy(ProxyType proxyType, string proxyHost, string proxyPort, string? proxyUsername, string? proxyPassword) : this(proxyType, proxyHost, proxyPort)
        {
            ProxyUsername = proxyUsername;
            ProxyPassword = proxyPassword;
        }

        [JsonProperty("proxyType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProxyType ProxyType { get; set; }

        [JsonProperty("proxyHost")]
        public string ProxyHost { get; set; }

        [JsonProperty("proxyPort")]
        public string ProxyPort { get; set; }

        [JsonProperty("proxyUsername", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ProxyUsername { get; set; }

        [JsonProperty("proxyPassword", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ProxyPassword { get; set; }
    }
}
