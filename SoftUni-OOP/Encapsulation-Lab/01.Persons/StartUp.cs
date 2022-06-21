using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 1; i <= n; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ');

                var person = new Person(commandArgs[0], commandArgs[1], int.Parse(commandArgs[2]));
                persons.Add(person);
            }

            persons.OrderBy(x => x.FirstName)
                .ThenBy(x => x.Age)
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
