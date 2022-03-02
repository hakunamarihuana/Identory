using Newtonsoft.Json;
using System;

namespace Identory.Models
{
    [Serializable]
    public sealed class ProxyTestResult
    {
        [JsonProperty("result")]
        public bool Result { get; }

        [JsonProperty("ip")]
        public string? IP { get; }
    }
}
