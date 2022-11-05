using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_Example
{
    class Car
    {
        public string model;
        public string color;
        public int year;
        int month = 2; // if var is not public then it can be accessible through method
        public Car(string pmodel, string pcolor, int pyear)
        {
            model = pmodel;
            color = pcolor;
            year = pyear;
        }
        public int getmonth()
        {
            return month;
        }
    }

}
