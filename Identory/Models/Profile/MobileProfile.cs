using Newtonsoft.Json;

namespace Identory.Models.Profile
{
    public class MobileProfile : IdentoryProfile
    {
        internal MobileProfile()
        {
        }

        public MobileProfile(string name)
        {
            Name = name;
        }

        [JsonProperty("isLandscape", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsLandScape { get; set; }

        [JsonIgnore]
        public string ScreenSize { get; private set; }

        [JsonProperty("screenSize")]
        private string screenSize
        {
            set { ScreenSize = value; }
        }
    }
}
