using Newtonsoft.Json;
using System;

namespace Identory.Models
{
    [Serializable]
    public sealed class BrowserStart
    {
        [JsonProperty("browserWSEndpoint")]
        public string BrowserWSEndpoint { get; set; }
    }
}
