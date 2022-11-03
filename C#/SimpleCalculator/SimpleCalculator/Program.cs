using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first value:");
            int value1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter airthmatic expression:");
            string action = Console.ReadLine();
            
            Console.Write("Enter second value:");
            int value2 = Convert.ToInt32(Console.ReadLine());
            
            Calculator calc = new Calculator(value1, value2, action);
            
            try
            {
                calc.Getsum();
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
        }
    }
}
