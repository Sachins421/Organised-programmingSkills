using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Errata
{
    public class Program
    {
        public static void Main(string[] args)
        {


            // Increment and Assignment operators
            var counter = 1;
            Console.WriteLine(counter++); // Running ++ AFTER counter will display 1
            Console.WriteLine(counter);


            // Logical negation operator
            var isTrue = true;
            Console.WriteLine(!isTrue);
            Console.WriteLine(!(1 > 2));


            // TypeOf, GetType and NameOf methods
            Console.WriteLine(typeof(System.IO.StreamReader));
            // Conversely, the `GetType()` method allows you to get the type information for a variable already in use.
            // Every object in C# has the `GetType()` method available.
            var myInt = 5;
            Console.WriteLine(myInt.GetType());


            //The[`nameof` expression]gives the name of a type or member as a string.
            //This is particularly useful when you are generating error messages.
            var ppl = new People { FirstName = "Sachin" };

            Console.WriteLine(nameof(People));
            Console.WriteLine(typeof(People));
            //Console.WriteLine(nameof(fritz.Name) + ": " + fritz.Surname);

            var streamType = "System.IO.MemoryStream";
            //var myStream = new DateTime();
            var myStream = Activator.CreateInstance("System.IO", streamType);

            Console.WriteLine(myStream.GetType());

            //String formatting 
            var greetmsg = "Hello";
            Console.WriteLine(greetmsg);

            //Concatenation 
            greetmsg += " world";
            Console.WriteLine(greetmsg);

            var greet = "Good";
            var time = DateTime.Now.Hour < 12 && DateTime.Now.Hour > 3 ? "Morning" : DateTime.Now.Hour > 12 && DateTime.Now.Hour < 15 ? "Afternoon" : "Evening";
            var name = "Sachin";

            // Use string.concat with a comma separated list of arguments 
            //Console.WriteLine(string.Concat(greet +" " +time +" "+ name)); //works
            Console.WriteLine(string.Concat(greet, " ", time, " ", name));

            var terms = new[] { greet, time, name };
            //Console.WriteLine(terms); // print type

            //Use string.Join to assembly values in an array with a separator
            Console.WriteLine(string.Join(" ", terms));

            // Use string.Format to configure a template string and load values into it based on position
            var format = "Good {0} {1}";

            Console.WriteLine(string.Format(format, time, name));

            var names = new[] { "Kumar", " Shukla" };

            // // With C# 7 and later you can now use string interpolation to format a string.  
            // Simply prefix a string with a $ to allow you to insert C# expressions in { } inside
            // a string
            Console.WriteLine($"Good {time} {name} {string.Join("", names)}");

            // Another technique that can be used when you don't know the exact number of strings
            // to concatenate is to use the StringBuilder class.

            var sb = new StringBuilder();
            sb.AppendFormat("Good {0}", time);
            sb.Append(" ");
            sb.Append(name);

            Console.WriteLine(sb.ToString());
            //You can turn a string into an array of strings using the Split method on a string variable.
            //Pass the character that identifies the boundary between elements of your array to turn it into an array:

            //var split = @"Good Morning ""Sachin""";
            //var split = @"Good Morning ""Sachin""
            //"; works
            var split = "Good Morning Sachin";
            //var result = split.Split(' ');
            var result = split.Split(Environment.NewLine);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(split.Split(' ')[1]);
            Console.WriteLine(split.Split(' ').Count()); // get the total count

            var fab = "1,2,3,4,5,6,6,7,8,8";

            foreach (var item in fab.Split(','))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(fab.Split(',')[2]);
            Console.WriteLine(fab.Split(',').Count()); // get the total count


            //******************* A Deeper Dive on Enums***********************
            

            var mylang = DotNetLanguage.csharp;

            Console.WriteLine(mylang);
            Console.WriteLine((byte)mylang);
            Console.WriteLine((int)mylang);

            mylang = (DotNetLanguage)10; // pass the same value which was assigned in enum
            Console.WriteLine(mylang);

            //var tlang = tLanguage.csharp;

            //Console.WriteLine(tlang);
            //Console.WriteLine((byte)tlang);
            //Console.WriteLine((int)tlang);

            //tlang = (tLanguage)50; // pass the same value which was assigned in enum
            //Console.WriteLine(tlang);

            var thislang = "csharp";
            mylang = Enum.Parse<DotNetLanguage>(thislang);
            Console.WriteLine(mylang);

            thislang = "CSharp";
            mylang = Enum.Parse<DotNetLanguage>(thislang,true); // to force to ignore case 
            Console.WriteLine(mylang);

            // TryParse has a similar signature, but returns a boolean to indicate success 
            var success = Enum.TryParse<DotNetLanguage>("VisualBasic", true, out var foo);
            Console.WriteLine(success);
            Console.WriteLine(foo);

            var lan = Enum.GetValues(typeof(DotNetLanguage));
            Console.WriteLine(lan);

            foreach (var item in lan)
            {
                Console.WriteLine(item);
                Console.WriteLine((DotNetLanguage)item);
            }

            //*******************Classes vs. Structs***********************
            /*
             * In the second session we introduced the class keyword to create reference types. 
             * There is another keyword, struct, that allows you to create Structure value types which will be allocated in memory and reclaimed more 
             * quickly than a class. While a struct looks like a class in syntax, there are some constraints:

                A constructor must be defined that configures all properties / fields
                The parameterless constructor is not allowed
                Instance Fields / Properties cannot be assigned in their declaration
                Finalizers are not allowed
                A struct cannot inherit from another type, but can implement interfaces
                Structs are typically used to store related numeric types. Let's tinker with an example:


                When should I use a struct instead of a class?
                This is a common question among C# developers. How do you decide? Since a struct is a simple value type, 
                there are several guidelines to help you decide:

                Choose a struct INSTEAD of a class if all of these are true about the type:

                It will be small and short-lived in memory
                It represents a single value
                It can be represented in 16 bytes or less
                It will not be changed, and is immutable
                You will not be converting it to a class (called boxing and unboxing)
            */

            //var structs = new Rectangle(); //it does not allow error if parameters dot not passed
            var structs = new Rectangle(5,6);
            Console.WriteLine(structs.area);
            Console.WriteLine(Rectangle.depth);

            var phone = new PhoneNumber(countryCode.India, "343435");
            Console.WriteLine(phone.getnumber());

            // ****************Initializing Collections*******************

            var myShapes = new List<Rectangle> {
                                    new (2, 5),
                                    new (3, 4),
                                    new (4, 3)
                                };
            foreach (var shape in myShapes)
            {
                Console.WriteLine(shape.area);
            }

            var myDictionary = new Dictionary<int, string> {
                                                {100, "C#"},
                                                {200, "Visual Basic"},
                                                {300, "F#"}
                                            };
            //******************Dictionay type*******************

            //Hashtable
            //This is the most efficient dictionary type with keys organized by the hash of their values.
            //David says: "Good read speed (no lock required), sameish weight as dictionary but more expensive to mutate and no generics!"
            var hashTbl = new Hashtable();
            hashTbl.Add("key1", "value1");
            hashTbl.Add("key2", "value2");

            Console.WriteLine(hashTbl["key1"]);
            Console.WriteLine(ppl.getdictonary());

            /*
             *ConcurrentDictionary
            A thread-safe version of Dictionary that is optimized for use by multiple threads. It is not recommended for use by a single thread due to the extra 
            overhead allocate for multi-threaded support.
            David says: "Poorish read speed, no locking required but more allocations require to update than a dictionary."
            Instead of Adding, Updating and Getting values from the ConcurrentDictionary, we TryAdd, TryUpdate, and TryGetValue. 
            TryAdd will return false if the key already exists, and TryUpdate will return false if the key does not exist. 
            TryGetValue will return false if the key does not exist. 
            We can also AddOrUpdate to add a value if the key does not exist and GetOrAdd to add a value if the key does not exist. 
             
             */

            var cd = new ConcurrentDictionary<string, string>();
            cd.AddOrUpdate("key1", "value1", (key, oldValue) => "value2");
            cd.AddOrUpdate("key1", "value1", (key, oldValue) => "value2");

            Console.WriteLine(cd.TryAdd("key2", "value1"));
            Console.WriteLine(cd);

            /*
             * ImmutableDictionary
                A new type in .NET Core and .NET 5/6 that is a read-only version of Dictionary. 
                Changes to it's contents involve creation of a new Dictionary object and copying of the contents.
                David says: "Poorish read speed, no locking required but more allocations required to update than a dictionary."
             * 
             */
            var d = ImmutableDictionary.CreateBuilder<string, string>();
            d.Add("key1", "value1");
            d.Add("key2", "value2");

            var theDict = d.ToImmutable();
            theDict = theDict.Add("key3", "value3");
            Console.WriteLine(theDict["key3"]);

            var student = new Student[] { new Student { name = "Sachin" }, new Student { name = "Shukla" } };

            Student.setInclass();
            foreach (var kvp in student)
            {
                Console.WriteLine(kvp.ToString());
            }

            Student.leaveClass();

            foreach (var kvp in student)
            {
                Console.WriteLine(kvp.ToString());
            }

            Console.ReadLine();
        }
    }
}
