using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Identifiable> identifiables = new List<Identifiable>();
            Identifiable identifiable = null;
            while (command != "End")
            {
                string[] inputInfo = command.Split(' ');

                if (inputInfo.Length == 2)
                {
                    string model = inputInfo[0];
                    string robotId = inputInfo[1];

                    identifiable = new Robot(robotId, model);
                }
                else if (inputInfo.Length == 3)
                {
                    string name = inputInfo[0];
                    int age = int.Parse(inputInfo[1]);
                    string id = inputInfo[2];

                    identifiable = new Citizent(id, name, age);
                }
                identifiables.Add(identifiable);
                command = Console.ReadLine();
            }
            string fakeId = Console.ReadLine();

            foreach (var item in identifiables)
            {
                if (item.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}