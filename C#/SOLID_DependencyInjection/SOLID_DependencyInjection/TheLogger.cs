using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DependencyInjection
{
    public class TheLogger //: IDisposable
    {
        public void CreateNewFile()
        {
            // actions to create log files
        }
        public string NameNewLogFile()
        {
            return DateTime.UtcNow.ToString("yyyyMMdd_HH") + ".log";
        }

        public void LogMessage(string message)
        {
            // Add message to current log file
            var formattedMessage = Format(message);
        }

        public string Format(string rawMessage)
        {
            return $"{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")} - {rawMessage}";
        }

        public void CloseLogFile()
        {
            // close the log file
        }

        public void Dispose()
        {
            CloseLogFile();
        }
    }
}
