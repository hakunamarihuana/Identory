using Newtonsoft.Json;

namespace Identory.Models.Profile
{
    public class DesktopProfile : IdentoryProfile
    {
        [JsonIgnore]
        public bool IsLandScape { get; private set; }

        [JsonProperty("isLandscape")]
        private bool isLandscape
        {
            set { IsLandScape = value; }
        }

        [JsonProperty("hasCustomScreenSize", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? UseCustomScreenSize { get; set; }

        [JsonProperty("customScreenWidth", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? CustomScreenWidth { get; set; }

        [JsonProperty("customScreenHeight", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? CustomScreenHeight { get; set; }

    }
}
