using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class NormalLoggerFormatter : ILoggerFormatter
    {

        public string FormatLogMessage(string rawMessage)
        {
            var msg = $"{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")} - {rawMessage}";
            Console.WriteLine(msg);
            return msg;
        }

    }
}
