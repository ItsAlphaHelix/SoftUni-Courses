using System;

namespace AnimalFarm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string nameOfChicken = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());

                Chicken chicken = new Chicken(nameOfChicken, age);

                Console.WriteLine($"Chicken {nameOfChicken} (age {age}) can produce {chicken.ProductPerDay} eggs per day.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
