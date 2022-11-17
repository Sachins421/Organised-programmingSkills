using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    internal class Program
    {
        /*
        Abstract Class:
                A Class which can be created but can not be implemneted and intatiated known as abstract class.
                Abstract class contain abstract and non-abstract method, abstract method 
                mandatorily override by the derived class.

        Interface: 
                 C# does not support the concept of mulitple inheritance, to achive this we need the help of interface.
            An interface contains method decleration and implementation can be done in corresponding class. You can add more than one interface to the particular class.

        Difference between interface and Abstract class:

                -> An abstract class contain both abstract method and non-abstract method where interface contain only abstract methods.
                -> Interface methods are public and abstract by default.
                -> Multiple inheritance can be achived by using interface.
                -> An interface can be called from anywhere to anywhere.
                -> Abstract class can be used for hierarchy of class representation and interface for specilization purpose.
        */
        abstract class Training
        {
            public abstract void Name();
            public abstract void email();
        }

        class Sachin : Training
        {
            public override void email()
            {
                Console.WriteLine("Name is Sachin");
            }

            public override void Name()
            {
                Console.WriteLine("Sachin@gmail.com");
            }
        }
        class Rahul : Training
        {
            public override void email()
            {
                Console.WriteLine("Name is Rahul");
            }

            public override void Name()
            {
                Console.WriteLine("Rahul@gmail.com");
            }
        }

        interface IOne
        {
            void name();
            void email();
        }
        interface ITwo
        {

            void name();
            void email();
        }
        class imp : IOne, ITwo
        {
            public void email()
            {
                Console.WriteLine("Name is Sachin"); ;
            }

            public void name()
            {
                Console.WriteLine("Shukla@gmail.com"); ;
            }
        }
        static void Main(string[] args)
        {
            Training[] training = new Training[]
            {
                new Sachin(),new Rahul()
            };
            
            foreach (Training t in training)
            {
                t.Name();
                t.email();
            }
            imp imp = new imp();
            imp.name();
            imp.email();

        }
    }
}
