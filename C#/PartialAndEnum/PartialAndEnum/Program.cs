using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
namespace PartialAndEnum
{
    public partial class student
    {
        // Partial Keyword
        //Classes can be defined across multiple files in separate class code blocks and then stitched together as a single class object.
        //This type of file layout and class design helps facilitate generating a class from metadata and allowing customization of that class in a second or third file.
        //You can use the partial keyword to define each of the parts of the class.

        //Check out the use of the partial keyword to define two partial Teacher classes and even a partial method called GetAge that is defined in one part and executed from the other.
        //Try removing the implementation of GetAge from the second class and see how the DisplayAge reflects this.
        public short Id { get; set; }
        public void callgetId()
        {
            getId();
        }
        partial void getId();
    }

    public partial class student
    {
        public string Name { get; set; }
        public void getName()
        {
            Console.WriteLine("Sachin");
        }

        partial void getId()
        {
            Console.WriteLine("23454");
        }

    }

    /*
    Enumerations
    An enumeration type is a value type that can be used to describe a collection of related named constants that actually reference an integral type. 
    We use the enum keyword to define these types with an access modifier and the name of the type. Values are then listed, separated by commas inside the enum block.

    By default, underlying values start with the value 0 and increment by 1. Let's take a look at an example that describes the values of a dimmer lightswitch:


    */
    class Student
    {

        public enum EnrolledState
        {
            NotEnrolled = 0,
            Enrolled = 5,
            OnMentorship = 10,
            Internship = 11,
            MilitaryLeave = 20
        }

        public EnrolledState Enroll()
        {

            // evaluate student's scenario, make a decision

            return EnrolledState.MilitaryLeave;

        }

    }
    public enum LightSwitch
    {
        Off ,
        FiftyPercent,
        Bright,
        on
    }

    /*
    Enum Flags
    Enums can also be used with bitwise operations so that you can store and pass along any number of values stored in one variable. 
    Use the [Flags] attribute to instruct the C# compiler to enable this feature and set explicit binary values for the enum constants. 
    You can use both integer values or binary values in your definitions.

    Then, you can store multiple values by using the bitwise OR operator | and can interact with those values using other bitwise operators.
     */

    [Flags]
    public enum FileAccess
    {

        // We can define values using integers and the powers of 2: like 2, 4, 8, 16.....
        Read = 1,
        Write = 2,
        Execute = 4
    }

    [Flags]
    public enum DaysOfWeek
    {
        // We can also use binary values directly by using the 0b binary prefix.
        // The _ character is used as a separator and is ignored by the compiler
        None = 0b_0000_0000,  // 0
        Monday = 0b_0000_0001,  // 1
        Tuesday = 0b_0000_0010,  // 2
        Wednesday = 0b_0000_0100,  // 4
        Thursday = 0b_0000_1000,  // 8
        Friday = 0b_0001_0000,  // 16
        Saturday = 0b_0010_0000,  // 32
        Sunday = 0b_0100_0000,  // 64
        Weekend = Saturday | Sunday
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var st = new student();
            st.getName();
            st.callgetId(); // inaccessible due to protection level

            LightSwitch hall = LightSwitch.Off;
            Console.WriteLine(hall);

            // We can force a value back to an integer with a simple cast:
            Console.WriteLine((int)LightSwitch.Off);

            var s = new Student();
            Console.WriteLine(s.Enroll());


            var access = FileAccess.Read | FileAccess.Write | FileAccess.Execute;
            Console.WriteLine(access);

            var workWeek = DaysOfWeek.Monday |
                DaysOfWeek.Tuesday |
                DaysOfWeek.Wednesday |
                DaysOfWeek.Thursday |
                DaysOfWeek.Friday;

            Console.WriteLine(workWeek);


        }
    }

}
