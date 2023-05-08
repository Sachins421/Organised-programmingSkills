using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static PracticeCsharp.Student;

namespace PracticeCsharp
{

    public class Student
    {

        // The new BirthDate field is declared with its Type and Access Modifier explicitly
        private DateTime _BirthDate;
        private string _FirstName;
        private string _LastName;

        public Student(string firstName, string lastName, DateTime birthDate)
        {
            this._FirstName = firstName;
            this._LastName = lastName;
            this._BirthDate = birthDate;
        }

        public string Name => $"{FirstName} {LastName}"; // fat arrow 

        // The FirstName property is ENCAPSULATED in the _FirstName field
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        // Using encapsulation techniques like this allows us to add code to take actions when the property is interacted with
        // ... In this case, we're notifying when the LastName is changed.
        public string LastName
        {
            get { return _LastName; }
            set
            {
                // Notify the teachers about the name change
                Console.WriteLine("Name change notification!");
                _LastName = value;
            }
        }

        // Total days / 365 to convert to years... not 100% accurate, but close enough for a demo
        public int Age => (int)Math.Floor(DateTime.Now.Subtract(_BirthDate).TotalDays / 365d);
        public bool IsEnrolled { get; set; } = true;


        ////// type record 
        public record StudentRecord(string FirstName, string LastName, int Age);

        ///// Param type 

        public decimal CalculateGradePointAverage(short enrollmentYear = 2020, params string[] classes)
        {

            Console.WriteLine("Calculating GPA for year " + enrollmentYear);

            foreach (var c in classes)
            {
                Console.WriteLine("Calculating for class " + c);
            }

            return 0.9m;

        }

        public decimal CalculateGradePointAverage(short enrollmentYear = 0)
        {

            if (enrollmentYear == 0) 
                enrollmentYear = (short)DateTime.Now.Year;

            Console.WriteLine("Calculating GPA for all classes in the year " + enrollmentYear);

            return CalculateGradePointAverage(enrollmentYear, "Art", "History", "Physics");

        }

        ///// out  and ref type 

        public bool GetStudentID(string studentName, out string ID) 
        {
            Random random = new Random();
            ID = Convert.ToString(random.Next());

            return true;
        }

        public void ChangeStudentID(ref string ID)
        {
            Random random = new Random();
            ID = Convert.ToString(random.Next());
        }

        // Delegate 

        public delegate decimal CalculaterHandler(decimal a, decimal b); // Delegates are sometimes referred to as Callback Functions

        public decimal CalculateInput(decimal a, decimal b, CalculaterHandler calculaterHander) // Implement single method reference
        {
            calculaterHander(a,b);
            return 0;
        }

        /*
        public decimal CalculateInput(decimal a, decimal b, params CalculaterHander[] calculaterHander)
        {
            //calculaterHander(a,b);
            foreach (var hander in calculaterHander) 
            {
                hander(a,b); 
            }
            return 0;
        }
        */ //Implementing chain of delegate method reference via param keyword 

        public decimal add(decimal a, decimal b)
        {
            var output = a + b;
            Console.WriteLine("Addition is : " + output);
            return output;
        }

        public decimal Subtract(decimal a, decimal b)
        {
            var output = a - b;
            Console.WriteLine("Subtract is : " + output);
            return output;
        }

    }
    public class Encapsulation
    {

        public static void Main(String[] args)
        {

            // Create a new Student object and assign it to the variable name `s`
            var s = new Student("SS", "Shukla", new DateTime(2003, 10, 1));
            s.LastName = "Sachin";
            s.FirstName = "Shukla";

            Console.WriteLine(s.FirstName);
            Console.WriteLine(s.LastName);
            Console.WriteLine(s.Name);

            var p = new StudentRecord("Sally", "Smith", 30);
            Console.WriteLine(p.FirstName);
            Console.WriteLine(p.LastName);
            Console.WriteLine(p.Age);

            Console.WriteLine(p.FirstName.ToString());

            Console.WriteLine("---Param Type---");

            Console.WriteLine(s.CalculateGradePointAverage(2019, "Hindi", "English" ));
            Console.WriteLine(s.CalculateGradePointAverage(classes:new [] {"Science","Art"})); //To avoid parameter 
            Console.WriteLine(s.CalculateGradePointAverage());

            Console.WriteLine("---Out and ref type---");

            string studentId = "";
            string studentName = "Keyword";
            if (s.GetStudentID(studentName,out studentId)) 
                Console.WriteLine($" Out and ref type : {studentName} {studentId}");
            studentId = "343";
            s.ChangeStudentID(ref studentId);
            Console.WriteLine(studentId);

            Console.WriteLine();
            Console.WriteLine("---Delegate---");
            Console.WriteLine();
            // call or pass method reftence By creating a object of delegate 
            var handler = new CalculaterHandler(s.Subtract);
            Console.WriteLine(handler(10,5));
            handler(10,5);

            // call or pass method refrence by calling delegate method handler 
            //s.CalculateInput(15,10, s.add, s.Subtract); // when implemented delegate message handler with param keyword and chain of methods

            //s.CalculateInput(15, 10, s.add);

            Console.WriteLine();
            Console.WriteLine("------Mulitcast Delgate------");
            Console.WriteLine();

            //Delegates can be combined with + and - operators to stack them and remove them from the stack to be executed.
            //As we'll see with Events in the next section, adding and removing references to delegates is very important.


            var handler2 = new CalculaterHandler(s.add);
            handler2 += new CalculaterHandler(s.Subtract);
            handler2 += new CalculaterHandler((arg1, arg2) => {
                var output = arg1 * arg2;
                Console.WriteLine("Mulitplication is : " + output); // Queue or stack all method ref in one variable and pass the reg to delegate handler method
                return output;
            });

            handler2 -= new CalculaterHandler(s.add); //Subtract method reference from the stack which was added earlier 

            s.CalculateInput(10, 5, handler2); // mulitple method references 

            Console.ReadLine();
        }
    }
}
