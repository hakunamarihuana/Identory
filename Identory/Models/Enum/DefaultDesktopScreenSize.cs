using System;
using System.Runtime.Serialization;

namespace Identory.Models.Enum
{
    [Serializable]
    public enum DefaultDesktopScreenSize
    {
        [EnumMember(Value = "1024x768")]
        Size_1024x768,
        [EnumMember(Value = "1280x720")]
        Size_1280x720,
        [EnumMember(Value = "1280x800")]
        Size_1280x800,
        [EnumMember(Value = "1280x1024")]
        Size_1280x1024,
        [EnumMember(Value = "1360x768")]
        Size_1360x768,
        [EnumMember(Value = "1366x768")]
        Size_1366x768,
        [EnumMember(Value = "1440x900")]
        Size_1440x900,
        [EnumMember(Value = "1536x864")]
        Size_1536x864,
        [EnumMember(Value = "1600x900")]
        Size_1600x900,
        [EnumMember(Value = "1680x1050")]
        Size_1680x1050,
        [EnumMember(Value = "1920x1080")]
        Size_1920x1080,
        [EnumMember(Value = "1920x1200")]
        Size_1920x1200,
        [EnumMember(Value = "2048x1152")]
        Size_2048x1152,
        [EnumMember(Value = "2560x1080")]
        Size_2560x1080,
        [EnumMember(Value = "2560x1440")]
        Size_2560x1440,
        [EnumMember(Value = "3440x1440")]
        Size_3440x1440,
        [EnumMember(Value = "3840x2160")]
        Size_3840x2160
    }
}
