using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ItemApp_Azurefunction
{
    public static class AssemblyIdentity
    {
        /// <summary>
        /// Returns the MisterSpex.PROD.GlassDBRequestProcessor assembly. Shorthand for registering of DI where this assembly is needed
        /// </summary>
        public static readonly Assembly Assembly = typeof(AssemblyIdentity).Assembly;
    }
    
}
