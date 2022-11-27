using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    /*
         What is draw back with collections?
         
         --> Typecasting mandatory
         --> will not restrict data
         --> We cannot perform action with multiple data

        Genrics allow to provide data type at runtime.
        If you write methods which performs action for all data types then we need Generics.
        Generics represented by <T>
        In place of <T> we can pass any data type at runtime

        Advantages:

           --> Write once and apply for all
           --> Provide security to data
           --> Reduce the size of the program
           --> No type casting is required

         */
    internal class Genere
    {   class Employ
        {
            public int empno;
            public string empname;

            public override string ToString()
            {
                return "Emp no. " + empno + "Emp Name "+empname;
            }
        }
        public void swap<T>(ref T a,ref T b)
        {
            T t;
            t = a;
            a = b;
            b = t;

            //Console.WriteLine("value of a and b are {0} {1}",a ,b);
        }
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;

            double c = 10.5;
            double d = 15.5;

            Genere gen = new Genere();
            gen.swap(ref a,ref b);
            Console.WriteLine("value of a and b are {0} {1}", a, b);
            gen.swap(ref c,ref d);
            Console.WriteLine("value of c and d are {0} {1}", c, d);

            Employ emp = new Employ();
            emp.empno = 123;
            emp.empname = "Sachin";

            Employ emp2 = new Employ();
            emp2.empno = 1423;
            emp2.empname = "Shukla";

            gen.swap(ref emp,ref emp2);
            Console.WriteLine("Details of object emp are {0} and \n emp2 {1}",emp, emp2);

        }
    }
}
