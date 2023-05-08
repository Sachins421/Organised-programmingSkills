using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsGenericsAndLINQ
{
    /*
         What is draw back with collections?
         
         --> Typecasting mandatory
         --> will not restrict data
         --> We cannot perform action with multiple data

        Genrics allow to provide data type at runtime.
        If you write methods which performs action for all data types then we need Generics.
        Generics represented by <T>
        In place of <T> we can pass any data type at runtime

        Advantages:

           --> Write once and apply for all
           --> Provide security to data
           --> Reduce the size of the program
           --> No type casting is required

         */
    public class Employ
    {
        public int empno;
        public string empname;

        public override string ToString()
        {
            return "Emp no. " + empno + "Emp Name " + empname;
        }

        public void swap<T>(ref T a, ref T b)
        {
            T t;
            t = a;
            a = b;
            b = t;

            //Console.WriteLine("value of a and b are {0} {1}",a ,b);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;

            double c = 10.5;
            double d = 15.5;

            Employ gen = new Employ();
            gen.swap(ref a, ref b);
            Console.WriteLine("value of a and b are {0} {1}", a, b);
            gen.swap(ref c, ref d);
            Console.WriteLine("value of c and d are {0} {1}", c, d);

            Employ emp = new Employ();
            emp.empno = 123;
            emp.empname = "Sachin";

            Employ emp2 = new Employ();
            emp2.empno = 1423;
            emp2.empname = "Shukla";

            gen.swap(ref emp, ref emp2);
            Console.WriteLine("Details of object emp are {0} and \n emp2 {1}", emp, emp2);

            //==============================Arrays=====================================================================

            //Problem with Arrays - The challenge with arrays is that you cannot easily add or remove objects from the array without going through a complex bit of resizing using the Array.Resize method.

            Console.WriteLine("====Array=====");

            //int[] numbers;
            int[] numbers = new int[3];

            // Numbers doesn't contain anything, as it wasn't assigned yet
            Console.WriteLine("Array is created: " + (numbers == null).ToString());

            // Create an array by using square brackets containing a size 
            //numbers = new int[3];
            Console.WriteLine("Array is null: " + (numbers == null).ToString());

            // The read-only Length property shows the number of elements in the array  
            Console.WriteLine("Array Size: " + numbers.Length);

            // Declare the array with initial values
            var fullArrayOfNumbers = new int[3] { 1, 2, 3 };
            Console.WriteLine("Array Size: " + fullArrayOfNumbers.Length);

            var matrix = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            Console.WriteLine(matrix.Length); //TODO how to access array

            //foreach (int i in matrix)
            //{
            //    Console.WriteLine(matrix[i, i]);
            //}

            // Access elements of the multi-dimensional using a comma between index values
            Console.WriteLine(matrix[1, 1]);

            Console.WriteLine("myNumbers");

            var myNumbers = new int[] { 1, 2, 3 };
            //foreach (var number in myNumbers)
            //{
            //    Console.WriteLine(number);
            //}

            // This doesn't work
            //myNumbers.Add(4);

            //You can change the size of a one-dimensional array using the Array.Resize method.
            //This method does not just resize the array, but rather creates a new array of the desired size and copies the values into that new array

            // This does
            //Array.Resize(ref myNumbers, 4);
            //myNumbers[3] = 4;
            //foreach (var number in myNumbers)
            //{
            //    Console.WriteLine(number);
            //}


            // Warning:
            // If you have a reference to the array somewhere else in your code, that reference will NOT be resized as well.Arrays are reference types, 
            // and references to the prior object are persisted.

            // Capture a reference to myNumbers
            var referenceToMyNumbers = myNumbers;

            // Change myNumbers
            Array.Resize(ref myNumbers, 5);
            myNumbers[4] = 100;

            // Arrays are enumerable and implement the IEnumerable interface, meaning you can iterate over the contents of a collection with a loop and interact with them:
            foreach (var number in myNumbers)
            {
                Console.WriteLine(number);
            }
            //referenceToMyNumbers = myNumbers; // You have to update the reference again to get the updated values.
            Console.WriteLine("referenceToMyNumbers");

            foreach (var number in referenceToMyNumbers)
            {
                Console.WriteLine(number);
            }

            // How to fill default value instead of creating one by one 
            var myOneArray = new int[3];
            Array.Fill(myOneArray, 1);

            foreach (var number in myOneArray)
            {
                Console.WriteLine(number);
            }

            // Remove is similar, and eliminates elements from the end of the array
            //Array.Resize(ref myNumbers, 3);
            //display(myNumbers);

            //==============================Hashtable and SortedList=====================================================================
            //A Hashtable and SortedList are collections of key/value pairs that contain no duplicate keys.
            //The Hashtable is sorted based on the hash hash of the keys and a SortedList is sorted based on the key value

            Console.WriteLine("Hashtable and SortedList");

            var fileExt = new Hashtable();
            //var fileExt = new SortedList();
            fileExt.Add("txt", "Plain text");
            fileExt.Add("mp3", "Compressed Music");
            fileExt.Add("jpg", "Jpeg Compressed Images");

            // No duplicates are allowed
            //fileExt.Add("mp3", "Sound effects");


            foreach (var number in fileExt)
            {
                Console.WriteLine("key and value pair are :" + ((DictionaryEntry)number).Key + " " + ((DictionaryEntry)number).Value);
                //Console.WriteLine(((DictionaryEntry)number).Key);
                //Console.WriteLine(((DictionaryEntry)number).Value);
            }
            //foreach (DictionaryEntry number in fileExt) // other way to access data
            //{
            //    Console.WriteLine(number.Value);
            //    Console.WriteLine(number.Key);
            //}

            //==============================Queue=====================================================================
            //A Queue is a collection of objects stored and accessed in a first-in / first-out manner. Enqueue to add elements to the Queue and Dequeue to remove elements from the Queue.
            //You can also Peek to inspect the oldest element in the Queue

            Console.WriteLine("====Queue====");

            var myQueue = new Queue();
            myQueue.Enqueue("First");
            myQueue.Enqueue("Second");
            myQueue.Enqueue("Third");

            foreach (var number in myQueue)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(myQueue.Count);
            Console.WriteLine(myQueue.Peek());

            myQueue.Dequeue();

            Console.WriteLine(myQueue.Peek());

            //==============================Stack=====================================================================
            //A Stack is a collection that is accessed in Last-in/First-out manner using the Push and Pop methods to add and remove items, with the Peek method available to examine the next item to be removed from the Stack.
            //I think of a Stack like a deck of cards: the last card that is placed on the top of the deck is the first to be dealt to a player.

            Console.WriteLine("====Stack====");

            var myHand = new Stack();
            myHand.Push("A-d");
            myHand.Push("A-s");
            myHand.Push("9-h");
            myHand.Push("9-s");
            myHand.Push("9-c");

            foreach (var number in myHand)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(myHand.Peek());

            var thisCard = myHand.Pop();
            Console.WriteLine(thisCard);

            Console.WriteLine("====");

            var deckOfCards = new Stack();
            deckOfCards.Push(new Card("A-d"));
            deckOfCards.Push(new Card("K-h"));

            // Now add a Joker card
            deckOfCards.Push("Joker");

            deckOfCards.Push(new Card("J-h"));

            foreach (var item in deckOfCards)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(deckOfCards);

            Console.ReadLine();

        }
    }

    class Card
    {
        public string Rank;
        public string Suit;
        public Card(string id)
        {
            Rank = id.Split('-')[0];
            Suit = id.Split('-')[1];
        }
        public override string ToString() { return Rank + "-" + Suit; }
    }
}