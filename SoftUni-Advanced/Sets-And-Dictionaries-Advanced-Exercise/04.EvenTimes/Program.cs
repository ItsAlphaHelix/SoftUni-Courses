using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> number = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int numbers = int.Parse(Console.ReadLine());

                if (!number.ContainsKey(numbers))
                {
                    number.Add(numbers, 0);
                }
                    number[numbers]++;
            }

            //int numb = number.Where(x => x.Value % 2 == 0).FirstOrDefault().Key;
            //int numb = number.FirstOrDefault(x => x.Value % 2 == 0).Key;

            foreach (var numb in number)
            {
                if (numb.Value % 2 == 0)
                {
                    Console.WriteLine(numb.Key);
                    break;
                }
            }
        }
    }
}
