using System.Reflection;

namespace Service
{
    public static class AssembelyIdentity
    {
        public static readonly Assembly Assembly = typeof(AssembelyIdentity).Assembly;
    }
}