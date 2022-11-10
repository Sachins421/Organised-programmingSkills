using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    internal class Animal
    {
        public virtual void sound()
        {
            //Inheritance with polymorphism
            Console.WriteLine("Animal make sound");
        }
    }
}
