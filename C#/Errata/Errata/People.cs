using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Errata
{
    public class People
    {
        public string FirstName { get; set; }
        public TimeSpan CalculateAge() => DateTime.Now.Subtract(new DateTime(2000, 1, 1));
        private readonly Dictionary<string, string> readonlyDictionary = new() {
                                            {"txt", "Text Files"},
                                            {"wav", "Sound Files"},
                                            {"mp3", "Compressed Music Files"}
                                           };

        

        public Dictionary<string,string> getdictonary()
        {
            return readonlyDictionary;
        }
    }
}
