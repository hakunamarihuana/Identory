using Newtonsoft.Json;
using System;

namespace Identory.Models
{
    [Serializable]
    public class JsonCookie
    {
        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("expirationDate")]
        public ulong ExpirationDate { get; set; }
        [JsonProperty("hostOnly")]
        public bool HostOnly { get; set; }

        [JsonProperty("httpOnly")]
        public bool HttpOnly { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("secure")]
        public bool Secure { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
