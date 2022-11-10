using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string var;
            Car mycar = new Car();
            mycar.function();
            Console.WriteLine(mycar.speed);
            Console.WriteLine(mycar.brandname);


            Animal myanimal = new Animal();
            Animal mypig = new Pig();
            Animal mydog = new Dog();

            Animal[] animals = {mypig, mydog}; 

            foreach (Animal animal in animals)
            {
                animal.sound();
            }
            //myanimal.sound();
            //mypig.sound();
            //mydog.sound();

            Console.ReadLine();
        }
    }
}
