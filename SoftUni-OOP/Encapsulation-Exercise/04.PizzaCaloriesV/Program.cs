using System;
using System.Collections.Generic;

namespace _04.PizzaCaloriesV
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine()
                .Split(' ');
                string[] doughInfo = Console.ReadLine()
                    .Split(' ');
                string pizzaName = pizzaInfo[1];
                string doughFlourType = doughInfo[1];
                string bakingTechnique = doughInfo[2];
                double doughgWeight = double.Parse(doughInfo[3]);

                Dough dough = new Dough(doughFlourType, bakingTechnique, doughgWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string toppingType = Console.ReadLine();

                while (toppingType != "END")
                {
                    string[] toppingInfo = toppingType
                        .Split(' ');
                    string type = toppingInfo[1];
                    double weight = double.Parse(toppingInfo[2]);

                    Topping topping = new Topping(type, weight);
                    pizza.AddTopping(topping);

                    toppingType = Console.ReadLine();
                }
                Console.WriteLine($"{pizza.Name} - {pizza.CalculateSummingOfCalories:F2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
