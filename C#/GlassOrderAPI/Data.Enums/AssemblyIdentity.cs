using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public class AssemblyIdentity
    {
        public static Assembly Assembly = typeof(AssemblyIdentity).Assembly;
    }
}
