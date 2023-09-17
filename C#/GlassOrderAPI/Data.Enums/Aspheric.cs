using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum Aspheric
    {
        [EnumMember(Value = "None")]
        None = 0,

        [EnumMember(Value = "Spheric")]
        Spheric = 1,

        [EnumMember(Value = "Aspheric")]
        Aspheric = 2,

        [EnumMember(Value = "Bi-Aspheric")]
        BiAspheric = 3,

        [EnumMember(Value = "Freeform")]
        Freeform = 4
    }
}

