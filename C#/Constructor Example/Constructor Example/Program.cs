using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // first method without parameter
            //Car featur = new Car();
            //featur.model = "Mustang";
            //featur.color = "red";
            //featur.year = 2005;

            //Console.WriteLine(featur.model);
            //Console.WriteLine(featur.color);
            //Console.WriteLine(featur.year);

            // Second method using constructor
            // constructor is used initialized default value to the variable when object is created for the class, costructor is called itself when object is created regardless of calling
            // it.
            Car featur = new Car("Mustang","red",2006);

            Console.WriteLine(featur.model);
            Console.WriteLine(featur.color);
            Console.WriteLine(featur.year);
            Console.WriteLine(featur.getmonth());
            Console.WriteLine(featur);
            Car.mymethod();
            Console.ReadLine();

        }
    }
}
