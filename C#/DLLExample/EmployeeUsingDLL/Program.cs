using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLLExample;

namespace EmployeeUsingDLL
{
    class Program
    {
        static List<Employ> employlist;
        public static void AddemoloyInput()
        {
            Employ employ = new Employ();
            Console.WriteLine("Enter emp no.");
            employ.empno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter emp name");
            employ.empname = Console.ReadLine();
            EmployMgt employMgt = new EmployMgt();
            Console.WriteLine(employMgt.Addemploy(employ));
            
        }
        public static void ShowEmploy() // with static keyword you do not need to create object
        {
            EmployMgt employMgt = new EmployMgt();
            employlist = employMgt.ShowEmploy();
            foreach (Employ employ in employlist)
            {
                Console.WriteLine(employ);
            }
        }
        static void Main(string[] args)
        { 
            int ch;

            do
            {
                Console.WriteLine("Options:....");
                Console.WriteLine("1: Add employ");
                Console.WriteLine("2: Show employ");
                Console.WriteLine("3: exit.");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        AddemoloyInput();
                        break;
                    case 2:
                        ShowEmploy();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("invlid input");
                        break;
                }


            } while (ch != 3);
        }
    }
}
