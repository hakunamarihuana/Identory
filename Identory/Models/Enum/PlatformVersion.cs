using System;
using System.Runtime.Serialization;

namespace Identory.Models.Enum
{
    [Serializable]
    public enum PlatformVersion
    {
    #region Windows
        [EnumMember(Value = "NT 5.1")]
        WindowsXP,
        [EnumMember(Value = "NT 6.0")]
        WindowsVista,
        [EnumMember(Value = "NT 6.1")]
        Windows7,
        [EnumMember(Value = "NT 6.2")]
        Windows8,
        [EnumMember(Value = "NT 6.3")]
        Windows81,
        [EnumMember(Value = "NT 10.0")]
        Windows10,
        [EnumMember(Value = "NT 10.0.2")]
        Windows11,
    #endregion
    #region Apple
        [EnumMember(Value = "10.13.0")]
        HighSierra10130,
        [EnumMember(Value = "10.13.1")]
        HighSierra10131,
        [EnumMember(Value = "10.13.2")]
        HighSierra10132,
        [EnumMember(Value = "10.13.3")]
        HighSierra10133,
        [EnumMember(Value = "10.13.4")]
        HighSierra10134,
        [EnumMember(Value = "10.13.5")]
        HighSierra10135,
        [EnumMember(Value = "10.13.6")]
        HighSierra10136,
        [EnumMember(Value = "10.14.0")]
        Mojave10140,
        [EnumMember(Value = "10.14.1")]
        Mojave10141,
        [EnumMember(Value = "10.14.2")]
        Mojave10142,
        [EnumMember(Value = "10.14.3")]
        Mojave10143,
        [EnumMember(Value = "10.14.4")]
        Mojave10144,
        [EnumMember(Value = "10.14.5")]
        Mojave10145,
        [EnumMember(Value = "10.14.6")]
        Mojave10146,
        [EnumMember(Value = "10.15.0")]
        Catalina10150,
        [EnumMember(Value = "10.15.1")]
        Catalina10151,
        [EnumMember(Value = "10.15.2")]
        Catalina10152,
        [EnumMember(Value = "10.15.3")]
        Catalina10153,
        [EnumMember(Value = "10.15.4")]
        Catalina10154,
        [EnumMember(Value = "10.15.5")]
        Catalina10155,
        [EnumMember(Value = "10.15.6")]
        Catalina10156,
        [EnumMember(Value = "10.15.7")]
        Catalina10157,
        [EnumMember(Value = "11.0")]
        BigSur110,
        [EnumMember(Value = "11.0.1")]
        BigSur1101,
        [EnumMember(Value = "11.1")]
        BigSur111,
        [EnumMember(Value = "11.2")]
        BigSur112,
        [EnumMember(Value = "11.2.1")]
        BigSur1121,
        [EnumMember(Value = "11.2.2")]
        BigSur1122,
        [EnumMember(Value = "11.2.3")]
        BigSur1123,
        [EnumMember(Value = "11.3")]
        BigSur113,
        [EnumMember(Value = "11.3.1")]
        BigSur1131,
        [EnumMember(Value = "11.4")]
        BigSur114,
        [EnumMember(Value = "11.5")]
        BigSur115,
        [EnumMember(Value = "11.5.1")]
        BigSur1151,
        [EnumMember(Value = "11.5.2")]
        BigSur1152,
        [EnumMember(Value = "11.6")]
        BigSur116,
        [EnumMember(Value = "11.6.1")]
        BigSur1161,
        [EnumMember(Value = "12.0")]
        Monterey120,
        [EnumMember(Value = "12.0.1")]
        Monterey1201,
        [EnumMember(Value = "12.1")]
        Monterey121,
        #region iOS/IpadOS
        [EnumMember(Value = "13.0")]
        iOS130,
        [EnumMember(Value = "13.1")]
        iOS131,
        [EnumMember(Value = "13.1.1")]
        iOS1311,
        [EnumMember(Value = "13.1.2")]
        iOS1312,
        [EnumMember(Value = "13.1.3")]
        iOS1313,
        [EnumMember(Value = "13.2.1")]
        iOS1321,
        [EnumMember(Value = "13.2.2")]
        iOS1322,
        [EnumMember(Value = "13.2.3")]
        iOS1323,
        [EnumMember(Value = "13.3")]
        iOS133,
        [EnumMember(Value = "13.3.1")]
        iOS1331,
        [EnumMember(Value = "13.4")]
        iOS134,
        [EnumMember(Value = "13.4.1")]
        iOS1341,
        [EnumMember(Value = "13.5")]
        iOS135,
        [EnumMember(Value = "13.5.1")]
        iOS1351,
        [EnumMember(Value = "13.6")]
        iOS136,
        [EnumMember(Value = "13.6.1")]
        iOS1361,
        [EnumMember(Value = "13.7")]
        iOS137,
        [EnumMember(Value = "14.0")]
        iOS140,
        [EnumMember(Value = "14.0.1")]
        iOS1401,
        [EnumMember(Value = "14.1")]
        iOS141,
        [EnumMember(Value = "14.2")]
        iOS142,
        [EnumMember(Value = "14.2.1")]
        iOS1421,
        [EnumMember(Value = "14.3")]
        iOS143,
        [EnumMember(Value = "14.4")]
        iOS144,
        [EnumMember(Value = "14.4.1")]
        iOS1441,
        [EnumMember(Value = "14.4.2")]
        iOS1442,
        [EnumMember(Value = "14.5")]
        iOS145,
        [EnumMember(Value = "14.5.1")]
        iOS1451,
        [EnumMember(Value = "14.6")]
        iOS146,
        [EnumMember(Value = "14.7")]
        iOS147,
        [EnumMember(Value = "14.7.1")]
        iOS1471,
        [EnumMember(Value = "14.8")]
        iOS148,
        [EnumMember(Value = "14.8.1")]
        iOS1481,
        [EnumMember(Value = "15.0")]
        iOS15,
        [EnumMember(Value = "15.0.1")]
        iOS1501,
        [EnumMember(Value = "15.0.2")]
        iOS1502,
        [EnumMember(Value = "15.1")]
        iOS151,
        [EnumMember(Value = "15.1.1")]
        iOS1511,
        [EnumMember(Value = "15.2")]
        iOS152,
        [EnumMember(Value = "15.2.1")]
        iOS1521,
        [EnumMember(Value = "15.3")]
        iOS153,
        [EnumMember(Value = "15.3.1")]
        iOS1531,

        #endregion
    #endregion
    #region Linux
        [EnumMember(Value = "Ubuntu 20.04.2 LTS")]
        Ubuntu20042LTS,
    #endregion
    }
}
