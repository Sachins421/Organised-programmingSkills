using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class LoggerFilenameManager : IFilenameManager
    {

        public string NameNewLogFile()
        {
            var filename = DateTime.UtcNow.ToString("yyyyMMdd_HH") + ".log";
            Console.WriteLine(filename);
            return filename;
        }

    }
}
