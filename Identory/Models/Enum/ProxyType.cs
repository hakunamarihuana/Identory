using System;
using System.Runtime.Serialization;

namespace Identory.Models.Enum
{
    [Serializable]
    public enum ProxyType
    {
        [EnumMember(Value = "socks4://")]
        SOCKS4,
        [EnumMember(Value = "socks5://")]
        SOCKS5,
        [EnumMember(Value = "http://")]
        HTTP,
        [EnumMember(Value = "ssh://")]
        SSH
    }
}
