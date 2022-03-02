using System;
using System.Runtime.Serialization;

namespace Identory.Models.Enum
{
    [Serializable]
    public enum Platform
    {
        [EnumMember(Value = "Win32")]
        Win32,
        [EnumMember(Value = "MacIntel")]
        MacIntel,
        [EnumMember(Value = "Linux x86_64")]
        Linux86_64,
        [EnumMember(Value = "iPhone")]
        IPhone,
        [EnumMember(Value = "iPad")]
        IPad
    }
}
