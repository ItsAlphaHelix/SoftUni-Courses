using CustomList;
using System;

namespace ImplementCustomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List item = new List();
            item.Add(0);
            item.Add(100);

            item.Print();
            
            Console.WriteLine("Count -> " + item.Count);
        }
    }
}