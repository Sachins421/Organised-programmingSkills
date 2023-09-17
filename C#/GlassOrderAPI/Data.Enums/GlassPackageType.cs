using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum GlassPackageType
    {
        [EnumMember(Value ="None")]
        None = 0,

        [EnumMember(Value = "STANDARD")]
        STANDARD = 1,

        [EnumMember(Value = "COMFORT")]
        COMFORT = 2,

        [EnumMember(Value = "PREMIUM")]
        PREMIUM = 3,

        [EnumMember(Value = "ULTRATHIN")]
        ULTRATHIN = 4,

        [EnumMember(Value = "SINGLEVISION")]
        SINGLEVISION = 5
    }
}
