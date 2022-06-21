using System;
using System.Collections.Generic;

namespace _09.ExplicitInterfaces
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<IPerson, IResident> info = new Dictionary<IPerson, IResident>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = inputInfo[0];
                string country = inputInfo[1];
                int age = int.Parse(inputInfo[2]);

                IPerson person = new Citizen(name, country, age);
                IResident citizen = new Citizen(name, country, age);
                info.Add(person, citizen);

                input = Console.ReadLine();
            }

            foreach (var item in info)
            {
                Console.WriteLine(item.Key.Name);
                Console.WriteLine($"{item.Value.GetName()} {item.Key.GetName()}");
            }
        }
    }
}
