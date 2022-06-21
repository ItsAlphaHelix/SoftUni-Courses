using System;
using System.Collections.Generic;

namespace _04.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continetsByCountriesCities =
                                    new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] commandsArgs = Console.ReadLine()
                    .Split(' ');
                string continent = commandsArgs[0];
                string country = commandsArgs[1];
                string citie = commandsArgs[2];

                if (!continetsByCountriesCities.ContainsKey(continent))
                {
                    continetsByCountriesCities.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continetsByCountriesCities[continent].ContainsKey(country))
                {
                    continetsByCountriesCities[continent].Add(country, new List<string>());
                }

                continetsByCountriesCities[continent][country].Add(citie);
            }

            foreach (var continet in continetsByCountriesCities)
            {

                Console.WriteLine($"{continet.Key}:");
                foreach (var item in continet.Value)
                {
                    Console.WriteLine($"{item.Key} -> {string.Join(", ", item.Value)}");
                }
            }
        }
    }
}
