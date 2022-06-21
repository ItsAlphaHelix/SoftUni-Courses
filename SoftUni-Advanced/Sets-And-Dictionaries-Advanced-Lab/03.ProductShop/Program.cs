using System;
using System.Collections.Generic;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shopByProductByPrice = 
                             new SortedDictionary<string, Dictionary<string, double>>();

            string command = Console.ReadLine();

            while (command != "Revision")
            {
                string[] commandArgs = command
                    .Split(", ");
                string name = commandArgs[0];
                string product = commandArgs[1];
                double price = double.Parse(commandArgs[2]);

                if (!shopByProductByPrice.ContainsKey(name))
                {
                    shopByProductByPrice.Add(name, new Dictionary<string, double>());
                }

                if (!shopByProductByPrice[name].ContainsKey(product))
                {
                    shopByProductByPrice[name].Add(product, price);
                }

                else
                {
                    shopByProductByPrice[name][product] = price;
                }
                command = Console.ReadLine();
            }

            foreach (var name in shopByProductByPrice)
            {
                Console.WriteLine($"{name.Key}->");
                foreach (var item in name.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
                
            }
        }
    }
}
