using System;
using System.Runtime.Serialization;

namespace Identory.Models.Enum
{
    [Serializable]
    public enum StartupAction
    {
        [EnumMember(Value = "DO_NOTHING")]
        DoNothing,
        [EnumMember(Value = "RESTORE_LAST_SESSION")]
        RestoreLastSession,
        [EnumMember(Value = "OPEN_THE_SPECIFIED_URL")]
        OpenSpecifiedUrl
    }
}
