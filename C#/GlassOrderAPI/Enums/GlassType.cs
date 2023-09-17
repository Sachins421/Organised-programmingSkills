using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum GlassType
    {
        [Description("None")]
        None =0,

        [Description("MONOFOCAL")]
        MONOFOCAL = 1,

        [Description("MULTIFOCAL")]
        MULTIFOCAL = 2,

        [Description("OFFICE")]
        OFFICE = 3,

        [Description("OPTICALFLAT")]
        OPTICALFLAT = 4

    }
}
