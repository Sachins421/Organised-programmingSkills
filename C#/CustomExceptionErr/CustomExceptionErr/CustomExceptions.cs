using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptionErr
{
    public class BetterDivisionException : System.Exception
    {
        //There are four constructor signatures that you SHOULD implement in your custom exception class,
        //and then you can implement any other properties or methods you would like. These are not required, but are considered good practice:
        public BetterDivisionException() : base("Unable to divide by zero") { }  // this one called 
        public BetterDivisionException(string message) : base(message) { }
        public BetterDivisionException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected BetterDivisionException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        // Remember, division is Dividend / Divisor

        public decimal? Dividend { get; set; }
        public decimal? Divisor { get; set; }
    }
    public class NegativeException : Exception // Microsoft now recommends Exception class to create a custom exception class instead of ApplicationException.
    {
        public NegativeException(string error) : base(error)
        {

        }
    }
    public class NumberZeroException : ApplicationException
    {
        public NumberZeroException(string error) : base(error)
        {

        }
    }

}
