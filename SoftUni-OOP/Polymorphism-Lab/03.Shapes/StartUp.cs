﻿using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(4.50, 6.50);
            Shape cirle = new Circle(4.50);

            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());

            Console.WriteLine(cirle.CalculateArea());
            Console.WriteLine(cirle.CalculatePerimeter());
            Console.WriteLine(cirle.Draw());
        }
    }
}
