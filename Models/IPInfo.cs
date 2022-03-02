using Newtonsoft.Json;
using System;

namespace Identory.Models
{
    [Serializable]
    public sealed class IPInfo
    {
        [JsonProperty("result")]
        public bool WasSuccessful { get; } = false;

        [JsonProperty("ip")]
        public string? IP { get; }

        [JsonProperty("country")]
        public string? Country { get; }

        [JsonProperty("countryCode")]
        public string? CountryCode { get; }

        [JsonProperty("region")]
        public string? Region { get; }

        [JsonProperty("city")]
        public string? City { get; }

        [JsonProperty("latitude")]
        public float? Latitude { get; }

        [JsonProperty("longitude")]
        public float? Longitude { get; }

        [JsonProperty("timezone")]
        public string? Timezone { get; }

        [JsonProperty("languages")]
        public string? Languages { get; }
    }
}
