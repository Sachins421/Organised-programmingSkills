using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLExample
{
    public class Employ
    {
        public int empno;
        public string empname;

        public override string ToString()
        {
            return "Empno  " + empno + "Emp Name " + empname;
        }
    }
}
