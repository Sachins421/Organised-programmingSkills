using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum ManufactureMethod
    {
        [EnumMember(Value = "None")]
        None = 0,
        [EnumMember(Value = "LocalMounting")]
        LocalMounting = 0,

        [EnumMember(Value = "RemoteMounting")]
        RemoteMounting = 0,

        [EnumMember(Value = "InhouseProduction")]
        InhouseProduction = 0
    }
}
