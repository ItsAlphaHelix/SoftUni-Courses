using System;
using System.Text.RegularExpressions;

namespace _01.SquareRoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string number = Console.ReadLine();

                double calc = Math.Sqrt(double.Parse(number));

                bool isNumber = double.TryParse(number, out double num);

                Console.WriteLine(calc);

                if (!isNumber || double.Parse(number) < 0)
                {
                    throw new ArgumentException("Invalid number");        
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}
