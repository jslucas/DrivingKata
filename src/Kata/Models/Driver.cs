using System;
using System.Collections.Generic;

namespace Kata
{
    public class Driver
    {
        public string Name { get; set; }
        public List<Trip> Trips { get; set; }

        public Driver(string name)
        {
            this.Name = name;
        }

        public Driver() { }
    }
}