using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DependencyInjection
{
    public abstract class LogSink
    {
        public abstract void WriteFile(string message);

        public virtual void disposeFile() { }
    }
}
