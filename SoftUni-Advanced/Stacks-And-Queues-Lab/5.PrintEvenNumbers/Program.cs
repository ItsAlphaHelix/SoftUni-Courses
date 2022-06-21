using System;
using System.Collections.Generic;
using System.Text;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfCarsToPassOfGreenLight = int.Parse(Console.ReadLine());

            string line = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int passedCars = 0;

            while (line != "end")
            {

                if (line == "green")
                {
                    for (int i = 0; i < numbersOfCarsToPassOfGreenLight; i++)
                    {
                        if (cars.Count > 0)
                        {
                            string car = cars.Dequeue();
                            Console.WriteLine($"{car} passed!");
                            passedCars++;
                        }
                    }
                }
                else
                {
                    string car = line;
                    cars.Enqueue(car);
                }
                line = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
