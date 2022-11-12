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
            // When you create constructor in both classes i.e. parent and dervied classes, while object creation of derived classes both class constructor will be called.
            // Similarly both static constructor will be called.

            // When you create the same method called myMethod in both classes i.e. parent and dervied classes,
            // while object creation of derived classes and call b.myMehtod, derived class method will be called because it will overwrite the method of parent classe..
            // To call the parent call method you can add base.mymethod in derived class mymethod function.
            //myanimal.sound();
            //mypig.sound();
            //mydog.sound();

            Console.ReadLine();
        }
    }
}
