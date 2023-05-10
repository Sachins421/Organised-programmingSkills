using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.AccessControl;
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
            //var card = new Card("F-R");

            foreach (var item in deckOfCards)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(deckOfCards);

            //==============================Generics=====================================================================
            //Generics are a way for you to force the type of a parameter from within client code. You declare the type generically using the convention <T> with a
            //class name or a method name and this allows that type to be passed around and enforced on those methods or properties in a class.
            //Most developers are familiar with using Generic Collections, which enforce the type of the objects in the collection. 
            //You'll find a Queue<T> and a Stack<T> available in the System.Collections.Generic namespace that mirror the versions we used above, as well as a few others list List<T> and Dictionary<T>.



            //List<T>
            //The List<T> is the most flexible of the generic collections, allowing you to add, remove, and access objects of the specified type.
            //Let's take a look at that deck of cards sample again:
            var listOfCards = new List<Card>();
            listOfCards.Add(new Card("A-d"));
            listOfCards.Add(new Card("J-d"));
            listOfCards.Add(new Card("9-c"));
            listOfCards.Add(new Card("8-s"));

            foreach(var card in listOfCards)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine(listOfCards.ElementAt(0)); // access the element

            Console.WriteLine(listOfCards[2]); // access the element

            var threeHearts = new Card("S-K");
            listOfCards.Insert(2,threeHearts); // insert new elements in existing index without deletig any element

            Console.WriteLine("----");

            foreach (var card in listOfCards)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine(listOfCards.IndexOf(threeHearts));
            //This list is generically typed to a Card and we read the type List < Card > in English as "List of type Card".Thanks to this typing,
            //we cannot add anything that isn't a card to the listOfCards:

            //listOfCards.Add("Joker");

            // Dictionary<TKey,TValue>
            // In some classes, you may have multiple type - arguments like the Dictionary class. In Dictionary<TKey, TValue> there are type arguments for the key and the value stored.

            var dic = new Dictionary<string, string>();
            //var dic = new SortedDictionary<string, string>(); // will sort the data according to the key 
            dic.Add("txt", "Plain text");
            dic.Add("mp3", "Compressed Music");
            dic.Add("jpg", "Jpeg Compressed Images");

            foreach (var number in dic)
            {
                //Console.WriteLine("key and value pair are :" + ((DictionaryEntry)number).Key + " " + ((DictionaryEntry)number).Value); do not need to use this keyword in dictonary
                Console.WriteLine(number.Key + number.Value); // will be shown in the way the values were added
            }

            Console.WriteLine(dic["jpg"]);
            Console.WriteLine(dic.Count);
            //Console.WriteLine(dic.ElementAt(1));

            for(var i = 0; i < dic.Count; i++)
            {
                Console.WriteLine(dic.ElementAt(i));// access all the elements
            }

            // ==============================Hashset===============================================
            //A Hashset is a high - performance collection that does not contain duplicate entries.

            var set = new HashSet<Card>();
            set.Add(new Card("J-c"));
            set.Add(new Card("A-c"));
            set.Add(new Card("9-d"));

            var threeHeart = new Card("3-h");
            set.Add(threeHeart);
            // If we attempt to add the 3 of Hearts a second time, it doesn't actually add another card to the Hashset because the 3 of Hearts is already present:
            set.Add(threeHeart);
            foreach (var card in set)
            {
                Console.WriteLine(card);
            }


            // ==============================Generic Classes===============================================
            //Ok, generics are cool... but how do you create your own classes or methods to work with them? Perhaps we have our own custom
            //collection object that randomly inserts objects into the collection and we want to work with the objects generically.
            //The official documentation on Generics has more details about how to interact with the managed types of the class.
            //Get started by declaring your class and methods using the <T> notation to indicate that this is a generic type-parameter where the characters
            //inside the angle-brackets are identical for all methods with the same characters.

            //List type of integer
            var list = new Gene<int>();
            list.setNumber(2);
            list.setNumber(3);
            list.setNumber(4);
            list.setNumber(5);
            list.setNumber(6);

            //foreach (var card in list.getAllValus()) //recommended way
            //{
            //    Console.WriteLine(card);
            //}

            Console.WriteLine("Generic list");

            foreach (var card in list.values)
            {
                Console.WriteLine(card);
            }

            // List of type string 
            var liststring = new Gene<string>();
            liststring.setNumber("SS");
            liststring.setNumber("So");

            //foreach (var card in list.getAllValus()) //recommended way
            //{
            //    Console.WriteLine(card);
            //}

            foreach (var card in liststring.values)
            {
                Console.WriteLine(card);
            }

            // List of type Card class object
            var deckn = new Gene<Card>();
            deckn.setNumber(new Card("A-d"));
            deckn.setNumber(new Card("9-d"));

            foreach (var card in deckn.values)
            {
                Console.WriteLine(card);
            }

            //List of type object
            var obj = new Gene<object>();
            obj.setNumber(new Card("S-S"));
            obj.setNumber(new Card("s-K"));
            obj.setNumber("joker");

            //Console.WriteLine(obj.values[0].GetType()); // can be stored different type of object
            //Console.WriteLine(obj.values[2].GetType());

            foreach (var card in obj.values)
            {
                Console.WriteLine(card.GetType());
            }

            /*
             Introducing LINQ and Lambda Expressions with LINQ to Objects
             LINQ (Language Integrated Query which Fritz keeps calling 'Language Integrated Natural Query') refers to a collection of technologies that allow you to query data. We're going to start with a subset of LINQ called LINQ to Objects that allow you to add predicate methods to IEnumerable<T> or IQueryable<T> collections to query them. We will dig in further to discuss how LINQ and LINQ to Objects works in our next session, and in the rest of this notebook we'll explore some simple interactions that are available.

             Let's look at that FritzSet<Card> collection again and load it with some Cards
             */

            Console.WriteLine("============LINQ==========");

            var deck = new Gene<Card>();
            deck.setNumber(new Card("A-d"));
            deck.setNumber(new Card("A-h"));
            deck.setNumber(new Card("A-c"));
            deck.setNumber(new Card("A-s"));
            deck.setNumber(new Card("9-d"));
            deck.setNumber(new Card("J-h"));
            deck.setNumber(new Card("3-c"));
            deck.setNumber(new Card("2-c"));
            deck.setNumber(new Card("7-d"));
            deck.setNumber(new Card("6-d"));
            deck.setNumber(new Card("5-d"));
            deck.setNumber(new Card("4-d"));
            deck.setNumber(new Card("4-h"));

            Console.WriteLine(deck.values.Count);
            Console.WriteLine(deck.values.Count(c => c.Suit == "d")); // gives count where suit equals to d
            Console.WriteLine(deck.values.Where(c => c.Suit == "d").Count()); // gives count where suit equals to d
            var value = deck.values.Where(c => c.Suit == "d");

            foreach (var card in value) 
                Console.WriteLine(card);

            // Filter to JUST the Diamonds        Then count the cards with rank Ace
            Console.WriteLine(deck.values.Where(c => c.Suit == "d").Count(c => c.Rank == "9"));

            // This returns a collection of Rank values
            var output = deck.values.Where(c => c.Suit == "d").Select(c => c.Rank);

            foreach (var card in output) Console.WriteLine(card);

            /// This reminds me of the card game 'Go-Fish':   Do you have any Queens?   No?  Go-Fish
            Console.WriteLine(deck.values.Any(c => c.Rank == "A"));

            // Do you have a flush, all cards are the same suit?
            Console.WriteLine(deck.values.All(c => c.Suit == "d"));

            // We can chain together these operations to analyze and inspect the collection.
            // Let's take that last example and filter out the cards in the clubs and hearts suits and see if we have a flush in diamonds:

            Console.WriteLine(deck.values.Where(c => c.Suit != "c" && c.Suit != "h").All(c => c.Suit == "d")); // Do you have a flush of Diamonds?

            // Do you have ANY cards that aren't clubs and are not hearts?
            Console.WriteLine(deck.values.Where(c => c.Suit != "c" && c.Suit != "h").Any());

            /*
             We can navigate around the collection using First, Skip, and Take methods.

             First : will grab the first element from the collection, or with an optional lambda argument, can return the first element that passes that test.
             Skip  : will pass over the first n number of elements
             Take  : will return a collection from the first position of the collection of the size specified
             */
            Console.WriteLine(deck.values.First());
            Console.WriteLine(deck.values.Skip(1));

            Console.WriteLine(deck.values.Skip(1).Take(2));

            /*
             OrderBy            :   orders the collection by a value provided in the method
             OrderByDescending  :   orders the collection in descending order by the value provided
             ThenBy             :   adds a secondary ordering to the collection after an OrderBy was specified
             ThenByDescending   :   adds a secondary ordering in descending order to the collection after an OrderBy was specified
             */

            Console.WriteLine(deck.values.OrderBy(c => c.Rank == "A" ? "ZZ" : c.Rank).Take(10));

            // Order by descending value of rank, converting an Ace into a 'ZZ' for ordering so that it is the first item in the collection
            Console.WriteLine(deck.values.OrderByDescending(c => c.Rank == "A" ? "ZZ" : c.Rank)
                .ThenByDescending(c => c.Suit)      // Then order by the Suite
                .Take(2));                          // Take the first two items from the collection


            Console.ReadLine();
    }
}   

    public class Gene<T>
    {
        public List<T> values = new List<T>();

        public void setNumber(T items)
        {
            var insertAt = values.Count == 0 ? 0 : new Random().Next(0, values.Count + 1);
            values.Insert(insertAt, items);
        }

        public List<T> getAllValus()  // recommended way
        {
             { return values; }
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