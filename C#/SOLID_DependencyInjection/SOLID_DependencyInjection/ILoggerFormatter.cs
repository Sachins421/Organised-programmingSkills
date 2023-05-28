using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DependencyInjection
{
    public interface ILoggerFormatter
    {  
            string FormatLogMessage(string rawMessage);
    }
    interface IFilenameManager
    {
        string NameNewLogFile();
    }

}
