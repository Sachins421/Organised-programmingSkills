using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptionErr
{
    public class Calculator
    {
        public void calc(int a, int b)
        {
            if (a < 0 || b < 0)
            {
                throw new NegativeException("Nos can not be in negative..");

            }
            if (a == 0 || b == 0)
            {
                throw new NumberZeroException("Nos can not be zero..");

            }
            else
            {
                double c = a + b;
                Console.WriteLine("Sum is {0}", c);
            }
        }
        public decimal DivideHandled(decimal arg1, decimal? arg2)
        {

            /**/
            if (arg2 == null) throw new BetterDivisionException("Cannot divide by null") { Dividend = arg1, Divisor = arg2 };
            if (arg2.Value == 0) throw new BetterDivisionException("Cannot divide by zero") { Dividend = arg1, Divisor = arg2 }; // if keep empty string this one called
            /**/

            return arg1 / arg2.Value;

        }
    }
}
