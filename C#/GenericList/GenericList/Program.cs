using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Employ
    {
        public int empno { get; set; }
        public string empname { get; set; }

        public override string ToString()
        {
            return "Emp No: " +empno + "Emp Name: "+empname ;
        }

    }
    class Demo
    {
        static List<Employ> employList;

        static Demo()
        {
            employList = new List<Employ>();

        }

        public string Addemploy(Employ employ)
        {
            employList.Add(employ);
            return "Employ added";

        }
        public void ShowEmploy()
        {
            foreach (Employ employ in employList)
            {
                Console.WriteLine(employ);
            }
        }

        public void AddemoloyInput()
        {
            Employ employ = new Employ();
            Console.WriteLine("Enter emp no.");
            employ.empno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter emp name");
            employ.empname = Console.ReadLine();
            Console.WriteLine(Addemploy(employ));
        }
        static void Main(string[] args)
        {
            Demo demo = new Demo();
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
                        demo.AddemoloyInput();
                        break;
                    case 2:
                        demo.ShowEmploy();
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
