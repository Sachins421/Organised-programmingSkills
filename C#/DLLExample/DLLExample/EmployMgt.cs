using System.Collections.Generic;
using System;
using System.Collections;

namespace DLLExample
{
    public class EmployMgt
    {
        static List<Employ> employlist;

        static EmployMgt()
        {
            employlist = new List<Employ>();
        }

        public string Addemploy(Employ employ)
        {
            employlist.Add(employ);
            return "Employ added";

        }

        public List<Employ> ShowEmploy()
        { 
                return employlist;
        
        }

    }
}