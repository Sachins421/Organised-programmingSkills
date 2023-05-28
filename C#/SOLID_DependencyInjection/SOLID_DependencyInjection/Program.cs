using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new TheLogger();
            Console.WriteLine(logger.Format("Error detected!"));
            logger.Dispose();

            Console.WriteLine("*****************Single Responsibility Principle (SRP)*************");
            var filemanager = new LoggerManager();
            //filemanager.LogMessage("Error detected", new AlertLoggerFormatter()); // passing object of class AlertLoggerFormatter which implements interface // O: The Open / Closed Principle (OCP)
            //filemanager.LogMessage("Error detected", new ExceptionLogFormatter(new Exception("Everything on Fire!"))); // passing object of class exceptionFormatter which implements interface
            filemanager.LogMessage("Error detected"); 
            filemanager.dispose();

            Console.ReadLine();
        }
    }
}