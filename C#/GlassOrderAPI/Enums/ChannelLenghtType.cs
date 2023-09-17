using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum ChannelLenghtType
    {

        [EnumMember(Value = "None")]
        None = 0,

        [EnumMember(Value = "SHORT")]
        SHORT = 1,

        [EnumMember(Value = "NORMAL")]
        NORMAL = 2
    }
}
