using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum ColourTingeFilteringOption
    {
        //Yes, No, No (with or without Lotus) + Yes (without Lotus)
        [EnumMember(Value = "NONE")]
        NONE = 0,

        [EnumMember(Value = "Yes")]
        Yes = 1,

        [EnumMember(Value = "No")]
        No = 2,

        [EnumMember(Value = "NoWithOrWithoutLotusAndYeswithoutLotus")]
        NoWithOrWithoutLotusAndYeswithoutLotus = 3
    }
}
