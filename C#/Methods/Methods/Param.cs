using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Param
    {
        public int add(params int[] values) //by param keyword you can pass any numbers of parameter
        {
            var sum = 0;
            foreach(var v in values)
            {
                sum += v;
            }

            return sum;
        }
    }
}
