using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class FileLogger : LogSink
    {
        string _fileName;
        IFilenameManager _filenameManager;

        public FileLogger(IFilenameManager filenameManager)
        {
            _filenameManager = filenameManager;
            _fileName = _filenameManager.NameNewLogFile();
            createNewFile(_fileName);
        }

        public void createNewFile(string message)
        {
            _fileName = message;
            Console.WriteLine($"Created new file {message}");
        }

        public override void WriteMessage(string fileName)
        {
            _fileName = fileName;
            Console.WriteLine($"Created log file {_fileName}");
        }

        public override void Dispose()
        {
            Console.WriteLine($"Cleaned up and closed log file {_fileName}");
        }
    }
}
