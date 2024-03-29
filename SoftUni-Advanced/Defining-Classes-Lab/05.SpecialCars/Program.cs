﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            string command;

            while ((command = Console.ReadLine()) != "No more tires")
            {
                List<string> tireSet = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                Tire[] currentTireSet = new Tire[4];
                for (int i = 0; i < 4; i++)
                {
                    Tire currentTire = new Tire(int.Parse(tireSet[0]), double.Parse(tireSet[1]));
                    currentTireSet[i] = currentTire;
                    tireSet.RemoveAt(0);
                    tireSet.RemoveAt(0);
                }
                tires.Add(currentTireSet);
            }
            while ((command = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine currentEngine = new Engine(int.Parse(engineInfo[0]), double.Parse(engineInfo[1]));
                engines.Add(currentEngine);
            }

            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = engines[int.Parse(carInfo[5])];
                Tire[] tireSet = tires[int.Parse(carInfo[6])];
                Car currentCar = new Car(carInfo[0], carInfo[1], int.Parse(carInfo[2]), double.Parse(carInfo[3]), double.Parse(carInfo[4]), engine, tireSet);
                cars.Add(currentCar);
            }

            cars = cars.Where(c =>
                c.Year >= 2017 && c.Engine.HorsePower > 330 && c.Tires.Sum(t => t.Pressure) >= 9 &&
                c.Tires.Sum(t => t.Pressure) <= 10).ToList();

            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
