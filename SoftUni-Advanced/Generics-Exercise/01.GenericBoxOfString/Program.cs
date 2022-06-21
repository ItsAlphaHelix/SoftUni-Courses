using System;
using System.Linq;

namespace _01.GenericBoxOfString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Box<double> box = new Box<double>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Add(input);
            }

            double itemToCompare = double.Parse(Console.ReadLine());
            int result =  box.CountGreaterThan(itemToCompare);
            Console.WriteLine(result);
        }
    }
}
