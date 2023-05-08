using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Globalization;

namespace EventsAndDelegates
{
    public class EnrolledArgs : EventArgs
    {
        public short EnrolledYear {get; set;}
        public string EnrolledMonth { get; set;} 
    }

    public class StudentGradeArgs : EventArgs
    {
        public int StudentGradeYear { get; set; }
        public string StudentGradeMonth { get; set; }
    }

    public class Student
    {
        // the sender
        //a class that contains any arguments about the event being raised.
        public delegate void EnrollmentHandler(object sender, EnrolledArgs args); //Delegate second para should be matched to EventArgs class

        public event EnrollmentHandler OnEnrolled; // The return type from an event is a delegate of type EventHandler that defines these two arguments.

        public void Enroll()
        {
            OnEnrolled(this, new EnrolledArgs { EnrolledYear = (short)DateTime.Now.Year, EnrolledMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month)});
        }

        public event EventHandler<StudentGradeArgs> OnStudentGrade;
        
        public void Grade(decimal grade)
        {
            if (grade > 70) //(OnStudentGrade != null)  
            {
                OnStudentGrade(this, new StudentGradeArgs { StudentGradeMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month), 
                    StudentGradeYear = (short)DateTime.Now.Year});
            }
               
        }
    }
    public class File
    {
        public static void Main(string[] args)
        {
            var dataFile = new DataFile();
            dataFile.Title = "Azure portal password";
            var encryptFile = new EncryptFile();

            var mailService = new MailService();
            var comp = new CompletedMsgs();

            encryptFile.EncryptedFile += mailService.EncryptedFile;
            encryptFile.EncryptedFile += comp.EncryptedFile;

            encryptFile.Encrypt(dataFile);

            var student = new Student();

            //student.OnEnrolled += (sender, args) => Console.WriteLine("Enrolled for the month and year : "+ args.EnrolledMonth, args.EnrolledYear);
            student.OnEnrolled += (sender, args) => Console.WriteLine($"Enrolled for the month and year : {args.EnrolledMonth} {args.EnrolledYear}");
            student.Enroll();

            student.OnStudentGrade += (sender, args) => Console.WriteLine($"Enrolled grade for the month and year : {args.StudentGradeMonth} {args.StudentGradeYear}");
            student.Grade(80);
            
            Console.ReadLine();

        }
    }

   
}
