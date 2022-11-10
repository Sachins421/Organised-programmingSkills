using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    internal class Pig : Animal
    {
        public override void sound()
        {
            Console.WriteLine("Pig make wee wee sound.");
        }
    }
}
