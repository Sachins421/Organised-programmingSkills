using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum AllowedLensTypeOption
    {
        [EnumMember(Value = "None")]
        None = 0,

        [EnumMember(Value = "NonStock")]
        NonStock = 1,

        [EnumMember(Value = "Stock")]
        Stock = 2
    }
}
