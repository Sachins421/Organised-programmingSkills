using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantDemo
{
        public class Student
        {

            // The new BirthDate field is declared with its Type and Access Modifier explicitly
            private DateTime BirthDate;
            private string _FirstName;
            private string _LastName;

            // Here is a publicly accessible constant
            public const int MaximumYearsEnrolled = 5;

            public Student() { IsEnrolled = true; }

            public Student(string firstName, string lastName, DateTime birthDate) : this()
            {
                this.BirthDate = birthDate;
                // We access the constant here by using its name
                Console.WriteLine("From the constructor, the maximum years enrolled: " + MaximumYearsEnrolled);
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public bool IsEnrolled { get; set; }

        
        public static void Main(string[] args)
        {
            // Create a new Student object and assign it to the variable name `s`
            var s = new Student("Sachin", "Kumar", new DateTime(2003, 10, 1));
            s.FirstName = "SS";
            //s.LastName = "SKS";

            // We can display the constant here 
            Console.WriteLine(Student.MaximumYearsEnrolled);
            Console.WriteLine(s.FirstName);
            Console.WriteLine(s.LastName);
        }
    }
}
