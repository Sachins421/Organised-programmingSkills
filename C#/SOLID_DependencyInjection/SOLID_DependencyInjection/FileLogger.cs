using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DependencyInjection
{
    public class FileLogger : LogSink
    {
        // class created based on FileLogger : Single Responsibility Principle (SRP)
        // A class should only have a single responsibility, that is, 
        //only changes to one part of the software's specification
       // should be able to affect the specification of the class.

        string _fileName;

        // This field and the constructor were added to complete the LSP implementation
        //LoggerFileManager manager = new LoggerFileManager();
        // Now referencing the interface as a type instead of the FilenameManager class
        IFilenameManager manager = new LoggerFileManager();

        public FileLogger()
        {
            _fileName = manager.NameNewLogFile();
            CreateNewFile(_fileName);
        }
        // end LSP implementation
        public void CreateNewFile(string fileName)
        {
            _fileName = fileName;
            Console.WriteLine($"File is created {_fileName}");
        }

        public override void WriteFile(string fileName)
        {
            Console.WriteLine("Wrote msg to disk.");
        }
        public override void disposeFile()
        {
            Console.WriteLine($"cleanup file name {_fileName}");
        }
    }

    public class LoggerFileManager : IFilenameManager 
    {
        public string NameNewLogFile()
        {
            var fileName = DateTime.UtcNow.ToLocalTime().ToString("F") + ".log";
            Console.WriteLine(fileName);
            return fileName;
        }
    }

    class AmericanSillyDateFormatFilenameManager : IFilenameManager
    {

        public string NameNewLogFile()
        {
            var filename = DateTime.UtcNow.ToString("MMddyyyy_HH") + ".log";
            Console.WriteLine(filename);
            return filename;
        }

    }

    class LoggerFormatter
    {

        public string FormatLogMessage(string rawMessage)
        {
            var msg = $"{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")} - {rawMessage}";
            Console.WriteLine(msg);
            return msg;
        }

    }

    // Compose these objects into a single LoggerManager object that handles the operations for ther rest of our application
    public class LoggerManager
    {
        LogSink filelogger = new FileLogger();
        //LoggerFormatter formatter = new LoggerFormatter();  

        public LoggerManager()
        {
            //var fileName = manager.NameNewLogFile();
            //filelogger.CreateNewFile(fileName);
        }

        //public void LogMessage(string msg)
        //{
        //    var fileformatter = formatter.FormatLogMessage(msg);
        //    filelogger.WriteFile(msg);
        //}

        public void LogMessage(string message)
        {
            LogMessage(message, new NormalLoggerFormatter());
        }

        public void LogMessage(string message, ILoggerFormatter formatter)
        {
            var newMessage = formatter.FormatLogMessage(message);
            filelogger.WriteFile(newMessage);
        }


        public void dispose()
        {
           filelogger.disposeFile();
        }
    }
}
