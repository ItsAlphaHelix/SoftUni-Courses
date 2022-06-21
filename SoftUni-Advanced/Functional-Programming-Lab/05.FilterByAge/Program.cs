using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> nameAndAge = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] splitted = Console.ReadLine()
                .Split(", ");

                string name = splitted[0];
                int age = int.Parse(splitted[1]);

                var person = new Person();
                person.Name = name;
                person.Age = age;
                nameAndAge.Add(person);
            }

            string typeName = Console.ReadLine();
            int typeAge = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = p => true;

            if (typeName == "older")
            {
                filter = p => p.Age >= typeAge;
            }

            else if (typeName == "younger")
            {
                filter = p => p.Age < typeAge;
            }

            var filterPeople = nameAndAge.Where(filter);

            string printName = Console.ReadLine();
            Func<Person, string> printFunc = p => p.Name + " " + p.Age;

            if (printName == "name age")
            {
                printFunc = p => p.Name + " - " + p.Age;
            }

            else if (printName == "name")
            {
                printFunc = p => p.Name;
            }

            else if (printName == "age")
            {
                printFunc = p => p.Age.ToString();
            }

            var personAsString = filterPeople.Select(printFunc);

            foreach (var str in personAsString)
            {
                Console.WriteLine(str);
            }
        }
        class Person
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}
