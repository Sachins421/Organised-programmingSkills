
using System.Collections.Concurrent;
using System.Collections.Generic;
using ProgramStructure;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> integetList = new List<int>();
        integetList.Add(1);
        integetList.Add(4);
        integetList.Add(6);
        integetList.Add(10);
        integetList.Add(5);
        integetList.Add(17);
        integetList.Add(19);


        foreach (int s in integetList) // int can be used here
        {
            Console.WriteLine(s);
        }

        System.Console.WriteLine("--");
        //var numbers = from a in integetList  where a > 15 select integetList;
        //var numbers = integetList.Select(s => s > 15); // Returns boolean value
        var numbers = integetList.Where(s => s > 15 || s < 6);
        foreach (var p in numbers) // int can't be used here, as p is IEnumerable
        {
            Console.WriteLine(p);
        }
        System.Console.WriteLine("Items List");
        var items = PrepareData.GetItems();
        var customers = PrepareData.GetCustomers();
        foreach (var p in items) // int can't be used here as p is IEnumerable
        {
            Console.WriteLine(p.ItemCode + " " + p.Name + " " + p.Price + " " + p.quantity);
        }

    }

}

//Console.WriteLine("Hello, World!");
// using directives
//If you include using directives, they must come first in the file, as in this example:


// using System.Text;

// StringBuilder builder = new();
// builder.AppendLine("Hello");
// builder.AppendLine("World!");

// Console.WriteLine(builder.ToString());


// A file with top-level statements can also contain namespaces and type definitions, 
//but they must come after the top-level statements. For example:
// MyClass.TestMethod();
// MyNamespace.MyClass.MyMethod();

// public class MyClass
// {
//     public static void TestMethod()
//     {
//         Console.WriteLine("Hello World!");
//     }

// }

// namespace MyNamespace
// {
//     class MyClass
//     {
//         public static void MyMethod()
//         {
//             Console.WriteLine("Hello World from MyNamespace.MyClass.MyMethod!");
//         }
//     }
// }


// The Console.ReadLine() method is used for reading a line of characters from the standard input stream (usually the keyboard).
// It doesn't directly relate to command-line arguments.
// run like dotnet run Sachin Shukla

//Console.ReadLine();

// switch (args.Length)
// {
//     case > 0:
//         {
//             foreach (var arg in args)
//             {
//                 Console.WriteLine($"Argument={arg}");
//             }

//             break;
//         }

//     default:
//         Console.WriteLine("No arguments");
//         break;
// }
