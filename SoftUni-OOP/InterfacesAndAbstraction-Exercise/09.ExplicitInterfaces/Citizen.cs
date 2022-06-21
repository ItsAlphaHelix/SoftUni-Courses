using System;
using System.Collections.Generic;
using System.Text;

namespace _09.ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; private set; }

        public string Country { get; private set; }

        public int Age { get; private set; }

        public string GetName()
        {
            return this.Name;
        }

        public string GetName(string name = "Mr/Ms/Mrs")
        {
            return name;
        }
    }
}
