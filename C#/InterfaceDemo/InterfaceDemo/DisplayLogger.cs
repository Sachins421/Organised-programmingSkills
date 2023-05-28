using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    public class DisplayLogger : ILogger
    {
        public int _ErrorCount = 0;
        public void LogError(string error)
        {
            Console.WriteLine("Error was supplied: " + error);
            _ErrorCount++;
        }
        //public int ErrorCount { get { return 5; } }
        //public int ErrorCounter { get { return _ErrorCount; } }

        public int ErrorCount { get { return _ErrorCount; } }
    }

    public class DBLogger : ILogger
    {
        public int _ErrorCount = 0;
        void ILogger.LogError(string error) // Explicit implementation of interface :It is also possible to HIDE the interface so
                                            // that it is only visible when the class is explicitly cast to the interface type.
        {
            Console.WriteLine("Explicit implementation error called: " + error);
            _ErrorCount++;
        }

        public int ErrorCount { get { return _ErrorCount; } }

    }

    class NewThing : ILogger2
    {
        public void DoSomethingElse()
        {
            Console.WriteLine("Something else?");
        }

        //public void DoTheThing()
        //{
        //    Console.WriteLine("I did the thing!");
        //}

    }
}
