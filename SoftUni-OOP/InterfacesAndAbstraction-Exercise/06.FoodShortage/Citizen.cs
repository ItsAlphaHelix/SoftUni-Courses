using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    public class Citizen : IName, IAge, IIdentifiable, IBirthday
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthday { get; }
    }
}
