using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> carList = new List<Car>();
            List<Engine> engineList = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = commandArgs[0];
                int power = int.Parse(commandArgs[1]);

                Engine engineInfo = new Engine(model, power);

                try
                {
                    if (Int32.TryParse(commandArgs[2], out _))
                    {
                        engineInfo.Displacement = commandArgs[2];
                    }

                    else
                    {
                        engineInfo.Efficiency = commandArgs[2];
                    }

                    if (Int32.TryParse(commandArgs[3], out _))
                    {
                        engineInfo.Displacement = commandArgs[3];
                    }

                    else
                    {
                        engineInfo.Efficiency = commandArgs[3];
                    }
                }
                catch (Exception)
                {   
                }

                engineList.Add(engineInfo);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = commandArgs[0];
                string engine = commandArgs[1];

                Car carInfo = new Car(model, engineList.First(x => x.Model == engine));

                try
                {
                    if (Int32.TryParse(commandArgs[2], out _))
                    {
                        carInfo.Weight = commandArgs[2];
                    }

                    else
                    {
                        carInfo.Color = commandArgs[2];
                    }

                    if (Int32.TryParse(commandArgs[3], out _))
                    {
                        carInfo.Weight = commandArgs[3];
                    }

                    else
                    {
                        carInfo.Color = commandArgs[3];
                    }
                }
                catch (Exception)
                {
                }
                carList.Add(carInfo);
            }

            Console.WriteLine(string.Join(Environment.NewLine, carList));
        }
    }
}
