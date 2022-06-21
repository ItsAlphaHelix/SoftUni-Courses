using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBirthable> birthable = new List<IBirthable>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = commandArgs[0];

                if (action == nameof(Citizen))
                {
                    string name = commandArgs[1];
                    int age = int.Parse(commandArgs[2]);
                    string id = commandArgs[3];
                    string birthDate = commandArgs[4];

                    Citizen person = new Citizen(name, age, id, birthDate);
                    birthable.Add(person);
                }
                else if (action == nameof(Pet))
                {
                    string name = commandArgs[1];
                    string birthDate = commandArgs[2];

                    Pet pet = new Pet(name, birthDate);
                    birthable.Add(pet);
                }
                command = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var date in birthable)
            {
                if (date.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(date.Birthdate);
                }
            }
        }
    }
}
