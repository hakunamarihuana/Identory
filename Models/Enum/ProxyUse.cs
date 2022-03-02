using System;

namespace Identory.Models.Enum
{
    [Serializable]
    public enum ProxyUse
    {
        NoProxy = 1,
        UseProxy = 2,
        TorProxy = 3,
        ProxyOverSSH = 6
    }
}
