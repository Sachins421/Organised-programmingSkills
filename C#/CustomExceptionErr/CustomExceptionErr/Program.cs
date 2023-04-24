using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptionErr
{
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

    internal class Program
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
                Console.WriteLine("Sum is {0}",c);
            }
        }
        static void Main(string[] args)
        {
            Program pr = new Program();

            try
            {
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                pr.calc(a, b);
            }
            catch (NegativeException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (NumberZeroException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Transaction done.");
            }
            Console.ReadLine();
        }
    }
}
