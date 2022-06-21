using System;

namespace ImplementCustomList
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List list = new List();

            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Insert(3, 50);
            list.Insert(4, 50);
            list.Insert(5, 100);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

           Console.WriteLine(list.Count);
        }
    }
}