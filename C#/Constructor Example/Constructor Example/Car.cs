using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_Example
{
    class Car
    {
        public string model;
        public string color;
        public int year;
        int month = 2; // if var is not public then it can be accessible through method

        static Car()
        {
            Console.WriteLine("This is static constructor.");
        }

        public Car(string pmodel, string pcolor, int pyear)
        {
            model = pmodel;
            color = pcolor;
            year = pyear;
        }
        public int getmonth()
        {
            return month;
        }
        public override string ToString() // This method is called when obj of the class is printed
        {
            return "This is tostring method " +model;
        }
        public static void mymethod() // static method or static var can be called with class name not with object of the class
        {
            Console.WriteLine("This is static method.");
        }
    }

}
