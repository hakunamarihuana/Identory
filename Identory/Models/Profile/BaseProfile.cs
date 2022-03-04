using Identory.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Identory.Models.Profile
{
    public abstract class BaseProfile
    {
        [JsonProperty("screenSize", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DefaultDesktopScreenSize ScreenSize { get; set; }

        [JsonProperty("uponStartup", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public StartupAction? OnStartUp { get; set; }

        [JsonProperty("platform", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Platform? Platform { get; set; }

        [JsonProperty("enableWebRTC", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? EnableWebRTC { get; set; }

        [JsonProperty("enableSwiftshader", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? EnableSwiftshader { get; set; }

        [JsonProperty("enableWebGL2", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? EnableWebGL2 { get; set; }

        [JsonProperty("randomizedRenderer", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? RandomizedRenderer { get; set; }

        [JsonProperty("randomizedMediaDevices", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? RandomizedMediaDevices { get; set; }

        [JsonProperty("replaceBatteryState", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? ReplaceBatteryState { get; set; }

        [JsonProperty("modifyAudioChannelData", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? ModifyAudioChannelData { get; set; }

        [JsonProperty("modifyWebGLBufferData", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? ModifyWebGLBufferData { get; set; }

        [JsonProperty("modifyCanvasHash", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? ModifyCanvasHash { get; set; }

        [JsonProperty("modifyClientRects", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? ModifyClientRects { get; set; }

        [JsonProperty("enableFontListMasking", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? EnableFontListMasking { get; set; }

        [JsonProperty("architecture", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual Architecture Architecture { get; set; }

        [JsonProperty("timezone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Timezone { get; set; }

        [JsonProperty("autoDetectAll")]
        public bool AutoDetectAll { get; set; } = true;

    }
}
