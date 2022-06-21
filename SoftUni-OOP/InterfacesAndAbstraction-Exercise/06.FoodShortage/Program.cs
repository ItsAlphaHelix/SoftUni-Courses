using System;
using System.Collections.Generic;

namespace _06.FoodShortage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Citizen> citizenList = new List<Citizen>();
            List<Rebels> rebelList = new List<Rebels>();
            int n = int.Parse(Console.ReadLine());
            int quantityOfFood = 0;

            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (inputInfo.Length == 3)
                {
                    Rebels rebel = new Rebels(inputInfo[0], int.Parse(inputInfo[1]), inputInfo[2]);
                    rebelList.Add(rebel);
                }
                else if (inputInfo.Length == 4)
                {
                   Citizen citizen = new Citizen(inputInfo[0], int.Parse(inputInfo[1]),
                   inputInfo[2], inputInfo[3]);
                   citizenList.Add(citizen);
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var rebelName in rebelList)
                {
                    string name = command;
                    if (rebelName.Name == name)
                    {
                        quantityOfFood += 5;
                    }
                }
                foreach (var citizenName in citizenList)
                {
                    string name = command;
                    if (citizenName.Name == name)
                    {
                        quantityOfFood += 10;
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(quantityOfFood);
        }
    }
}
