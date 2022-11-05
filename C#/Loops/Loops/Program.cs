using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            // foor loop in different ways
            for (int i = 1; i < 20; i++)
            {
                for (int j = 20 - i ; j > 0; j--)
                {
                    Console.Write("*");                 
                }

             Console.WriteLine();
                
            }

            for (int p = 1; p < 20; p++)
            {
               for (int k = p; k != 0; k--)
                {
                    Console.Write("*");
                }
             Console.WriteLine();
            }

            // Difference between while and do while loop is that do-while loop will execute at least once even though condition does not match where while loop won't.
            
            // While loop
            int r = 5;
            while (r < 5)
            {
                Console.WriteLine(r);
                r++;
            }

            // do-while loop
            int s = 5;
            do
            {
                Console.Write(s); 
                s++;
            }
            while (s < 5);
            Console.ReadLine();

        }
    }
}
