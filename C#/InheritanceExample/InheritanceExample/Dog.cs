﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    internal class Dog : Animal
    {
        public override void sound()
        {
            Console.WriteLine("Dog make bhow bhow sound.");
        }
    }
}
