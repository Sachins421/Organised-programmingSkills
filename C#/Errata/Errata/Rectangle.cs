using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Errata
{
    struct Rectangle
    {
        public Rectangle(int x, int y)
        {
            this.lenght = x;
            this.width = y;
        }
        //public const int depth = 1;
        public static readonly int depth = DateTime.Now.Minute;
        public int lenght { get; set; }
        public int width { get; set; }  

        public int area => lenght * width;

    }

    struct PhoneNumber
    {
        public PhoneNumber(countryCode Code, string number)
        {
            this.countryc = Code;
            this.phoneNumber = number;
        }

        public string phoneNumber { get; set; }
        public countryCode countryc { get; set; }

        public string getnumber()
        {
            return countryc + phoneNumber;
        }
    }
}
