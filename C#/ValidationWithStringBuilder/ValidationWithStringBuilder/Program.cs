using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationWithStringBuilder
{
    internal class Program
    {
        class Emplyee
        {
            public int empno;
            public string empName;
            public string DepName;
            public int basic;
        }

        class DataValidation
        {
            public StringBuilder validate(Emplyee employ)
            {
                StringBuilder sb = new StringBuilder();
                bool flag = true;
                if (employ.empno <= 2)
                {
                    sb.AppendLine("Emp no. must be with at least 4 digit \n");
                    flag = false;
                }
                if (employ.empName.Length <= 5)
                {
                    sb.Append("Emp Name must with 6 char \n");
                    flag = false;
                }
                if (!employ.DepName.Equals("NAV"))
                {
                    sb.Append("Dept must be NAV \n");
                    flag = false;
                }
                if (flag)
                {
                    Console.WriteLine("All validation are passed!");
                }
                return sb;
            }
        }
        static void Main(string[] args)
        {
            Emplyee employ = new Emplyee();
            Console.WriteLine("Enter the emp no.");
            employ.empno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the emp name.");
            employ.empName = Console.ReadLine();
            Console.WriteLine("Enter the department.");
            employ.DepName = Console.ReadLine();
            Console.WriteLine("Enter the basic.");
            employ.basic = Convert.ToInt32(Console.ReadLine());

            DataValidation dv = new DataValidation();
            Console.WriteLine(dv.validate(employ));
        }
    }
}
