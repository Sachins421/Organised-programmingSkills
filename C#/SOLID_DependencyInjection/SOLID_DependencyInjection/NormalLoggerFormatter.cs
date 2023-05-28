using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DependencyInjection
{
    // O: The Open / Closed Principle (OCP)
    public class NormalLoggerFormatter : ILoggerFormatter
    {
        public string FormatLogMessage(string rawMessage)
        {
            var msg = $"{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")} - Normal Logger Formatter {rawMessage}";
            Console.WriteLine(msg);
            return msg;
        }
    }

    public class AlertLoggerFormatter : ILoggerFormatter
    {
        public string FormatLogMessage(string rawMessage)
        {
            var msg = $"{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")} - Alert msg: {rawMessage}";
            Console.WriteLine(msg);
            return msg;
        }
    }
}
