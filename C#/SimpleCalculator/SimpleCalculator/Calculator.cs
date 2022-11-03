using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Calculator
    {
        public int InputValue1;
        public int Inputvalue2;
        public string action;

        public Calculator(int aInputValue, int bInputValue, string aAction)
        {
            InputValue1 = aInputValue;
            Inputvalue2 = bInputValue;
            action = aAction;
        }

        public void Getsum()
        {
            if (action == "+")
            {
                Console.WriteLine(InputValue1 + Inputvalue2);
            }
            else if (action == "-")
            {
                Console.WriteLine(InputValue1 - Inputvalue2);
            }
            else if (action == "/")
            {
                Console.WriteLine(InputValue1 / Inputvalue2);
            }
            else if (action == "*")
            {
                Console.WriteLine(InputValue1 * Inputvalue2);
            }
            else
            {
                Console.WriteLine("Invalid input."); 
            }
            
        }
    }
}
