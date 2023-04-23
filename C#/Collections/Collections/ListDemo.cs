using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class student
    {
        public int Id { get; set; }
        public string Name { get; set; }    

       
    }
    internal class ListDemo
    {
        public List<int> intList;
        public List<Object> order; // decleration
        public List<string> stringList; 
        public List<string> bigCities = new List<string>() // decleration and initialization
                    {
                        "New York",
                        "London",
                        "Mumbai",
                        "Chicago"
                    };
        public string[] cities = new string[3] { "Mumbai", "London", "New York" };

        public ListDemo()
        {
            intList = new List<int>();
            order = new List<Object>();
            stringList = new List<string>();

        }

        public void DoSomething() 
        {
            intList = new List<int>();
            order = new List<Object>(); // Bad practice to initiaze in function
        }

        public void setvalue(List<int> intvalue, List<object> obj)
        {
            this.intList = intvalue;
            this.order = obj;
        }

        // Sorted list 

        public SortedList<int, string> numberNames = new SortedList<int, string>() // Dictionay and Hashtable can also be used 
                                    {
                                        {3, "Three"},
                                        {5, "Five"},
                                        {1, "One"}
                                    };

    }
}
