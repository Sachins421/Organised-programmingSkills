using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum ServicePriceType
    {
        [EnumMember(Value = "None")]
        None = 0,

        [EnumMember(Value = "Service")]
        Service = 1,

        [EnumMember(Value = "Polish")]
        Polish = 2
    }
}
