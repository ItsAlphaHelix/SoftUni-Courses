using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Dictionary<string, Person> people = new Dictionary<string, Person>();
                Dictionary<string, Product> products = new Dictionary<string, Product>();

                string[] personInfo = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);
                string[] productsInfo = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var curentPerson in personInfo)
                {
                    string[] personArgs = curentPerson
                        .Split('=');

                    string name = personArgs[0];
                    decimal money = decimal.Parse(personArgs[1]);

                    Person person = new Person(name, money);
                    people.Add(person.Name, person);
                }

                foreach (var currentProduct in productsInfo)
                {
                    string[] productArgs = currentProduct
                        .Split('=');
                    string name = productArgs[0];
                    decimal cost = decimal.Parse(productArgs[1]);

                    Product product = new Product(name, cost);
                    products.Add(product.Name, product);
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] purchaseInfo = command.Split(' ');
                    Person person = people[purchaseInfo[0]];
                    Product product = products[purchaseInfo[1]];

                    if (person.Money - product.Cost < 0)
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                        command = Console.ReadLine();
                        continue;
                    }

                    person.AddProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");

                    command = Console.ReadLine();
                }
                foreach (var person in people)
                {
                    string productMessage = person.Value.Product.Count == 0
                        ? "Nothing bought"
                        : string.Join(", ", person.Value.Product.Select(x => x.Name));

                    Console.WriteLine($"{person.Key} - {productMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}