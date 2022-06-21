using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    public class Rebels : IName, IAge, iGroup
    {
        public Rebels(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; }

        public int Age { get; }

        public string Group { get; }
    }
}
