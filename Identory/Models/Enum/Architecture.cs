using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Identory.Models.Enum
{
    [Serializable]
    public enum Architecture
    {
        [EnumMember(Value = "x86")]
        x86,
        [EnumMember(Value = "arm")]
        arm
    }
}
