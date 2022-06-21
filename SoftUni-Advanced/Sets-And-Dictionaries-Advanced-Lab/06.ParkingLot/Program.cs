using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            HashSet<string> cars = new HashSet<string>();

            while (command != "END")
            {
                string[] commandArgs = command.Split(",");
                string direction = commandArgs[0];
                string carNumber = commandArgs[1];
   
                if (direction == "IN")
                {
                    cars.Add(carNumber);
                }

                if (direction == "OUT")
                {
                    cars.Remove(carNumber);
                }
                command = Console.ReadLine();
            }
            if (cars.Count <= 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
