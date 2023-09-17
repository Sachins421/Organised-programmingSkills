using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum TingeType
    {
        [EnumMember(Value = "None")]
        None = 0,

        [EnumMember(Value = "MIRRORED")]
        MIRRORED = 1,

        [EnumMember(Value = "PHOTOTROPHIC")]
        PHOTOTROPHIC = 2,

        [EnumMember(Value = "POLARIZED")]
        POLARIZED = 3,

        [EnumMember(Value = "ORIGINAL")]
        ORIGINAL = 4,

        [EnumMember(Value = "FILTER")]
        FILTER = 5,

        [EnumMember(Value = "GRADIENT")]
        GRADIENT = 6
    }
}
