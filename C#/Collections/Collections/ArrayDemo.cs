using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class ArrayDemo
    {
        // Deleration 

        public int[] arraynum; 
        public string[] arraystr;

        // Initialization through contructor
        public ArrayDemo()
        {
            arraynum = new int[7] {1,2,3,4,55,5,5};  
            arraystr = new string[2] {"ArrayString 1","ArrayString 2" };
        }

        public int[] evenNums = new int[2] { 1, 2 };
        public string[] cities = new string[3] { "Mumbai", "London", "New York" };
    }
}
