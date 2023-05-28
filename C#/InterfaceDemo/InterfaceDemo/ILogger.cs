using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    public interface ILogger
    {
        //Members in interface are public by default
        void LogError(string error);    
        int ErrorCount { get; }
    }

    ///////////////////////////Default Implementations////////////////////////////////////////////////////////////////////////////////

    public interface IDoAThing
    {
        void DoTheThing();
    }
    public interface ILogger2 : IDoAThing
    {
        void DoSomethingElse();
        void IDoAThing.DoTheThing()
        {
            Console.WriteLine("This is my default thing");
        }
    }
}
