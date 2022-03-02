using System;
using System.Runtime.Serialization;

namespace Identory.Models.Enum
{
    [Serializable]
    public enum DeviceType
    {
        [EnumMember(Value = "Desktop / Laptop")]
        DekstopOrLaptop,
        [EnumMember(Value = "Mobile")]
        Mobile
    }
}
