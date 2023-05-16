using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Errata
{
    public class Student
    {
        public string name;
        public static bool inClass;

        public static void setInclass()
        {
            inClass = true;
        }

        public static void leaveClass()
        {
            inClass = false;
        }

        public override string ToString()
        {
            return name +" : " + inClass;
        }
    }
}
