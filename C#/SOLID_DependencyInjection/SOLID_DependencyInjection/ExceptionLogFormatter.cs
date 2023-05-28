using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DependencyInjection
{
    public class ExceptionLogFormatter : ILoggerFormatter
    {
        Exception _exception;

        public ExceptionLogFormatter(Exception exception) // contructor
        {
            _exception = exception;
        }

        public string FormatLogMessage(string message) 
        {
            var msg = $"{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")} - Exception of type {_exception.GetType().Name} with message '{_exception.Message}' logged: {message}";
            Console.WriteLine(msg);
            return msg;
        }
    }
}
