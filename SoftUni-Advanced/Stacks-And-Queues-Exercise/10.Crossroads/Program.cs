﻿using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightInSeconds = int.Parse(Console.ReadLine());
            int freeWindowInSeconds = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int passedCar = 0;
            bool isHitted = false;

            while (command != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                }
                else
                {
                    int currentGreenLight = greenLightInSeconds;

                    while (cars.Count > 0 && currentGreenLight > 0)
                    {
                        string currentCar = cars.Dequeue();

                        if (currentGreenLight - currentCar.Length >= 0)
                        {
                            currentGreenLight -= currentCar.Length;
                            passedCar++;
                            continue;
                        }
                        if (currentGreenLight + freeWindowInSeconds - currentCar.Length >= 0)
                        {
                            currentGreenLight = 0;
                            passedCar++;
                            continue;
                        }

                        string hittedChar = currentCar
                            .Substring(currentGreenLight + freeWindowInSeconds, 1);

                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {hittedChar}.");
                        isHitted = true;
                        //Environment.Exit(0);
                        return;
                    }
                }
                command = Console.ReadLine();
            }
            if (!isHitted)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCar} total cars passed the crossroads.");
            }
        }
    }
}
