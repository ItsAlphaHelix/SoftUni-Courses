using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ');
                string model = commandArgs[0];
                int fuelAmount = int.Parse(commandArgs[1]);
                double fuelConsumptionForOneKm = double.Parse(commandArgs[2]);

                Car listOfCars = new Car(model, fuelAmount, fuelConsumptionForOneKm);
                cars.Add(listOfCars);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandArgs = command
                    .Split(' ');
                string model = commandArgs[1];
                int fuelAmountOfKm = int.Parse(commandArgs[2]);

                cars.First(x => x.Model == model).Drive(fuelAmountOfKm);

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
