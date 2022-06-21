using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
   public class StartUp
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
                int engineSpeed = int.Parse(commandArgs[1]);
                int enginePower = int.Parse(commandArgs[2]);
                int cargoWeight = int.Parse(commandArgs[3]);
                string cargoType = commandArgs[4];

                List<Tires> tiresInfo = new List<Tires>();

                for (int tireIndex = 5; tireIndex <= 12; tireIndex += 2)
                {

                    double tirePressures = double.Parse(commandArgs[tireIndex]);
                    int tireAge = int.Parse(commandArgs[tireIndex + 1]);

                    Tires tires = new Tires(tireAge, tirePressures);
                    tiresInfo.Add(tires);
                }
                Engine engineInfo = new Engine(engineSpeed, enginePower);
                Cargo cargoInfo = new Cargo(cargoType, cargoWeight);
                Car carInfo = new Car(model, engineInfo, cargoInfo, tiresInfo);
                cars.Add(carInfo);
            }

            string type = Console.ReadLine();

            if (type == "fragile")
            {
                List<Car> fragileCars = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(x => x.Pressure < 1))
                    .ToList();

                foreach (var model in fragileCars)
                {
                    Console.WriteLine(model.Model);
                }
            }

            else if (type == "flammable")
            {
                List<Car> flammableCars = cars
                    .Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250)
                    .ToList();

                foreach (var model in flammableCars)
                {
                    Console.WriteLine(model.Model);
                }
            }
        }
    }
}
