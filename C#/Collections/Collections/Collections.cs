using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Collections
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Arrays-------------------------------------------------------
            //var varArray = new ArrayDemo();

            //Array.Reverse(varArray.arraynum);
            //foreach(var i in varArray.arraynum)
            //{
            //    Console.WriteLine(i);
            //}
            //foreach (var i in varArray.arraystr)
            //{
            //    Console.WriteLine(i);
            //}

            //Array.Sort(varArray.arraynum); // sorting 

            //for (var i = 0; i < varArray.arraynum.Length; i++)
            //{
            //    Console.WriteLine(varArray.arraynum[i]);
            //}

            ////LINQ methods 
            //Console.WriteLine(varArray.arraynum.Max());
            //Console.WriteLine(varArray.arraynum.Average());


            //List---------------------------------------------------------

          //public List<student> std = new List<student>()
          //  {
          //      new student(){ Id = 1, Name="Bill"},
          //      new student(){ Id = 2, Name="Steve"},
          //      new student(){ Id = 3, Name="Ram"},
          //      new student(){ Id = 4, Name="Abdul"}
          //  };

            var list = new ListDemo();

            list.intList.Add(0);
            list.intList.Add(1);
            list.intList.Add(2);

            list.order.Add("Order 234235");
            list.order.Add("Order 435456");

            list.order.Remove(10); // removes the first 10 from a list

            list.intList.RemoveAt(2); //removes the 3rd element (index starts from 0)

            list.intList.Contains(2);
            //foreach (var i in list.order)
            //{
            //    Console.WriteLine(i);
            //}

            ////list.DoSomething();

            //foreach(var i in list.intList)
            //{
            //    Console.WriteLine(i);
            //}

            list.setvalue(list.intList, list.order);

            list.stringList.AddRange(list.cities); // add array to list object

            foreach (var i in list.order)
            {
                Console.WriteLine(i);
            }

            //list.DoSomething();

            foreach (var i in list.intList)
            {
                Console.WriteLine(i);
            }

            foreach (string i in list.stringList)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("---Initial key-values--");

            foreach (KeyValuePair<int, string> kvp in list.numberNames)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

            list.numberNames.Add(6, "Six");
            list.numberNames.Add(2, "Two");
            list.numberNames.Add(4, "Four");

            foreach (KeyValuePair<int, string> kvp in list.numberNames)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

        }
    }
}
