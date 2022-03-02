using Identory.Converters;
using Identory.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Identory.Models.Profile
{
    [Serializable]
    public class IdentoryProfile
    {

        [JsonIgnore]
        public DeviceType DeviceType { get; private set; }

        [JsonProperty("deviceType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        private DeviceType deviceType
        {
            set { DeviceType = value; }
        }

        [JsonProperty("group", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? GroupId { get; set; }

        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ProfileId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uponStartup", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public StartupAction? OnStartUp { get; set; }

        [JsonProperty("startPageURL", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? StartupPageURL { get; set; }

        [JsonProperty("platform", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Platform? Platform { get; set; }

        [JsonProperty("platformVersion", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PlatformVersion? PlatformVersion { get; set; }

        [JsonIgnore]
        public string ChromeVersion { get; private set; }

        [JsonProperty("chromeVersion", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(EnumToStringConverter))]
        private string chromeVersion
        {
            set { ChromeVersion = value; }
        }

        [JsonIgnore]
        public DateTime LastStartTime { get; private set; }

        [JsonProperty("lastStartAt", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private DateTime? lastStartTime
        {
            set { LastStartTime = value ?? DateTime.UnixEpoch; }
        }

        [JsonIgnore]
        public DateTime CreatedAt { get; private set; }

        [JsonProperty("createdAt", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private DateTime createdAt
        {
            set { CreatedAt = value; }
        }

        [JsonProperty("hasCustomChromeVersion", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? UseCustomChromeVersion { get; set; }

        [JsonProperty("customChromeVersion", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? CustomChromeVersion { get; set; }


        //[JsonProperty("windowSizeIsSet")]
        //public bool WindowSizeIsSet { get; }
        #region ProxySettings
        [JsonProperty("useProxy", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ProxyUse? UsedProxyType { get; set; }

        [JsonProperty("proxyType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProxyType? ProxyType { get; set; }

        [JsonProperty("proxyHost", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ProxyHost { get; set; }

        [JsonProperty("proxyPort", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ProxyPort { get; set; }

        [JsonProperty("proxyUsername", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ProxyUsername { get; set; }

        [JsonProperty("proxyPassword", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ProxyPassword { get; set; }
        #endregion

        /// <summary>
        /// Make sure to disable <see cref="AutoDetectTimezone"/> before setting a custom timezone.
        /// </summary>
        [JsonProperty("timezone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Timezone { get; set; }

        /// <summary>
        /// Make sure to disable <see cref="AutoDetectLanguages"/> before setting custom languages.
        /// </summary>
        [JsonProperty("languages", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[]? Languages { get; set; }


        #region AutoDetectSettings
        [JsonProperty("autoDetectTimezone")]
        public bool AutoDetectTimezone { get; set; } = true;

        [JsonProperty("autoDetectLanguages")]
        public bool AutoDetectLanguages { get; set; } = true;

        [JsonProperty("autoDetectGeolocation")]
        public bool AutoDetectGeolocation { get; set; } = true;

        [JsonProperty("autoDetectIp")]
        public bool AutoDetectIp { get; set; } = true;

        [JsonProperty("autoDetectAll")]
        public bool AutoDetectAll { get; set; } = true;
        #endregion

        /// <summary>
        /// Make sure to disable <see cref="AutoDetectIp"/> before setting webRTCRemoteIP;
        /// </summary>
        [JsonProperty("webRTCRemoteIP", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? WebRTCRemoteIP { get; set; }

        [JsonProperty("disableWebRTC", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? DisableWebRTC { get; set; }

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

        [JsonProperty("videoInputs", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? VideoInputsCount { get; set; }

        [JsonProperty("audioInputs", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? AudioInputsCount { get; set; }

        [JsonProperty("audioOutputs", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? AudioOutputsCount { get; set; }

        [JsonProperty("additionalFonts", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[]? AdditionalFonts { get; set; }

        [JsonProperty("latitude", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float? Latitude { get; set; }

        [JsonProperty("longitude", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float? Longitude { get; set; }

        [JsonProperty("overrideCookies", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public JsonCookie[]? OverrideCookies { get; set; }

        [JsonProperty("customUserAgent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? UseCustomUserAgent { get; set; }

        [JsonProperty("userAgent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? CustomUserAgent { get; set; }

        [JsonProperty("customWebGLParameters", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? UseCustomWebGlParameters { get; set; }

        [JsonProperty("customWebGLVendor", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? CustomWebGlVendor { get; set; }

        [JsonProperty("customWebGLReneder", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? CustomWebGLRenderer { get; set; }
    }
}
