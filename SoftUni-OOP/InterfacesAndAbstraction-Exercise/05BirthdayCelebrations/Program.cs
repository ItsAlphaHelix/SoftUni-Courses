using System;
using System.Collections.Generic;

namespace _05BirthdayCelebrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split(' ');
                IIdentifiable identifiable = null;
                Robot robot = null;
                if (command == "Citizen")
                {
                    string name = commandArgs[1];
                    int age = int.Parse(commandArgs[2]);
                    string id = commandArgs[3];
                    string birthDate = commandArgs[4];

                    identifiable = new Citizen(name, age, id, birthDate);
                }
                else if (command == "Pet")
                {
                    string name = commandArgs[1];
                    string birthDate = commandArgs[2];

                    identifiable = new Pet(name, birthDate);
                }
                else if (command == "Robot")
                {
                    string model = commandArgs[1];
                    string id = commandArgs[2];

                    robot = new Robot(model, id);
                }

                identifiables.Add(identifiable);
                command = Console.ReadLine();
            }

            string endWithBirthdate = Console.ReadLine();

            foreach (var item in identifiables)
            {
                if (item.Birthdate.EndsWith(endWithBirthdate))
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
        }
    }
}
