using System.Reflection;

namespace WebAPI
{
    public class AssemblyIdentity
    {
        public static Assembly Assembly = typeof(AssemblyIdentity).Assembly;
    }
}
