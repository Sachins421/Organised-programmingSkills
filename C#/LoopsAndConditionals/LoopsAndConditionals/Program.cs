using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopsAndConditionals
{
    public class Orange
    {
        public void MakeJuice() { Console.WriteLine("Making orange juice"); }
    }

    public class Apple
    {
        public void MakePie() { Console.WriteLine("Making apple pie"); }
    }

    public class Student
    {
        public string Name { get; set; }
        public string Hello() { return "World!"; }
    }
    internal class Program
    {
        /*
         
          There is another scenario that you will see many developers use to prioritize the compound boolean test inside an if statement, 
          and that is using the 'short circuit' operators && and ||. They're referred to as a 'short circuit' operators because they evaluate 
          the first condition on the left and if necessary evaluate the condition on the right side of the operator.

          The && operator is called the Conditional Logical AND operator or referred to as AndAlso in Visual Basic. This operator behaves as follows:

          Evaluate the left-side of the operator
          IF the left-side evaluates to false, return false and stop processing
          ELSE return the result of evaluating the right-side of the operator 
        
         */


        /*
         Pattern Matching
         A recent addition to the C# specification is Pattern Matching. Pattern Matching is the ability to test and match on whether a condition being tested is of a certain shape and
         optionally assign that value to a variable during the conditional evaluation.

         The is operator "is" used in the conditional testing process: 
         */



        /*
         Conditional Operators
         There are a number of operators that you can use to perform one-line interactions to conditionally assign values to variables or for using in other expressions. 
        While these operators make your code shorter and sometimes easier to read, other times it can make for confusing statements when you chain together a number of these operators. 
        As with any language feature or tool, a little bit goes a long way.

        The Ternary Conditional Operator ? :
        The Conditional Operator evaluates the term to the left of the ? and returns the value between the ? and : if the condition returns true. It returns the value to the right of the : if false. The following format makes this a little clearer: 
         */


        /*
         The Null-Coalescing Operator ??
         The Null-coalescing operator allows us to inspect the value to the left of the ?? and if that value is null, 
         return the value to the right of the ??. You can even combine this with an equals sign = to assign a value of the left side is null.

         This is MUCH simpler than the syntax you would have to use if the operator was not available:

         var output = (myValue != null) ? myValue : some_other_value 
         */


        /*
         The Null-Conditional Operator ?.
         What happens if you want to work with an object, but you're not sure if it is null. The Null-Conditional Operator allows you to test if the object is null and conditionally continue execution.
 
         Early in development of this operator, it was sometimes referred to as the 'Elvis Operator' for the appearance of a curly hair above two eyes.
         If the object is null, the expression evaluates to null. This may be inconvenient in our processing, but we can use some of our other operators to help structure our code: 
         */

        public static void Main(string[] args)
        {
            var seconds = DateTime.Now.Second;

            bool MultipleOfThree()
            {
                Console.WriteLine("MultipleOfThree was called");
                return seconds % 3 == 0;
            }

            // seconds = 7;
            Console.WriteLine("Current seconds: " + seconds);

            // Test for BOTH multiple of 2 AND a multiple of 3
            if (seconds % 2 == 0 && MultipleOfThree())  // ====================> short circuit operator 
            {
                Console.WriteLine("Seconds are even AND a multiple of 3");
            }
            else if (seconds % 2 == 0)
            {
                Console.WriteLine("Seconds are even");
            }
            else if (seconds % 3 == 0)
            {
                Console.WriteLine("Seconds are a multiple of 3");

                // Test for seconds to be a multiple of 5 OR a multiple of 7
            }
            else if (seconds % 5 == 0 | seconds % 7 == 0)
            {
                Console.WriteLine("Seconds are a multiple of 5 OR 7");
            }
            else
            {
                Console.WriteLine("Seconds are neither even nor a multiple of 3");
            }

            if (seconds % 2 == 0 || MultipleOfThree()) // ====================> short circuit operator 
            {
                Console.WriteLine("Seconds are even or a multiple of three");
            }

            //======================================Pattern Matching 

            object fruit = new Orange();

            // Is this object an Apple?
            if (fruit is Apple a)
            {
                a.MakePie();

                // Is it an Orange?
            }
            else if (fruit is Orange o)
            {
                o.MakeJuice();

            }
            else
            {
                Console.WriteLine("I don't know what to do with this fruit");
            }


            //================================>Ternary operator 

            // test if the seconds are a multiple of two
            Console.WriteLine("The current seconds are: " + seconds);
            //                              if true
            //                                           if false
            var result = seconds % 2 == 0 ? "Even" : "Odd";
            Console.WriteLine(result);

            var result2 = seconds % 2 == 0 ?
                        (seconds % 3 == 0 ? "Even and Multiple of 3" : "Even")
                        : "Odd";


            Console.WriteLine(result2);

            //========================================>> The Null-Coalescing Operator ??

            //string myValue = "test";
            string myValue = null;
            Console.WriteLine(myValue ?? "It's null");

            //=========================================>> Null-Conditional Operator ?

            Student s = new Student { Name = "Sachin" };
            //Student s = null;
            //Student s = new Student();
            //                          if s is null, return null
            //                          else evaluate the Name property
            Console.WriteLine("Our student's name is: " + s?.Name);

            Console.WriteLine(s?.Hello());

            //                          if s is not null, evaluate the Name property
            //                          else return the string 'Student is not assigned yet'
            Console.WriteLine("Our student's name is: " + (s?.Name ?? "Student is not assigned yet"));


            //==============================================> Switch statement 

            var dayOfTheWeek = DateTime.Now.DayOfWeek;
            //dayOfTheWeek = DayOfWeek.Friday;

            switch (dayOfTheWeek)
            {
                case DayOfWeek.Monday:
                    Console.WriteLine("Does somebody have a case of the Mondays?");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("It's TACO TUESDAY at the cafe!");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("Middle of the work-week... almost done!");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("Friday is ALMOST HERE!!");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("The weekend starts.... NOW!");
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("Relaxing... no school, no work...");
                    break;
                case DayOfWeek.Sunday:
                    Console.WriteLine("School and work tomorrow?  Better have some fun NOW!");
                    break;
                default:
                    Console.WriteLine("I don't care what day of the week it is... we're on HOLIDAY!");
                    break;
            }

            var hourOfDay = DateTime.Now.Hour;
            switch (dayOfTheWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday when hourOfDay < 16:
                    Console.WriteLine("Work work work...");
                    break;
                case DayOfWeek.Friday when (hourOfDay >= 16 && false):
                    Console.WriteLine("The weekend starts.... NOW!");
                    break;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine("Relaxing... no school, no work...");
                    break;

            }

            var name = "Sachin";

            foreach (var letter in name)
            {
                Console.WriteLine(letter);
            }
        }
    }
}
