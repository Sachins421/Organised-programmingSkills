using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    // Compose these objects into a single LoggerManager object that handles the operations for ther rest of our application
    class LoggerManager : IDisposable
    {

        // Referencing the LogSink abstract class so that we can change our abstract interaction with LogSinks later
        LogSink _Logger;

        public LoggerManager(LogSink sink)
        {
            _Logger = sink;
        }
        //TODO : what is .net core and .net framework, .net standard and .net xamrin?
        public void LogMessage(string message)
        {
            LogMessage(message, new NormalLoggerFormatter());
        }


        // Referencing the ILoggerFormatter so that we can inject the desired formatter
        public void LogMessage(string message, ILoggerFormatter formatter)
        {
            var newMessage = formatter.FormatLogMessage(message);
            _Logger.WriteMessage(newMessage);
        }

        public void Dispose()
        {
            _Logger.Dispose();
        }

    }

}
