using Identory.Models.Enum;
using Newtonsoft.Json;

namespace Identory.Models.Profile
{
    public class DefaultProfile : BaseProfile
    {
        [JsonProperty("screenSize", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DefaultDesktopScreenSize ScreenSize { get; set; }

        [JsonProperty("randomScreenSize", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? UseRandomScreenSize { get; set; }

        [JsonProperty("randomScreenMax", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DefaultDesktopScreenSize MaxRandomScreenSize { get; set; }

        [JsonProperty("randomScreenMin", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DefaultDesktopScreenSize MinRandomScreenSize { get; set; }

        [JsonProperty("chromeVersionLimit", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public VersionLimit ChromeVersionLimit { get; set; }

        [JsonProperty("patformVersionLimit", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public VersionLimit PlatformVersionLimit { get; set; }

        [JsonProperty("autoSetLanguages", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool AutoSetLanguages { get; set; }
    }
}
