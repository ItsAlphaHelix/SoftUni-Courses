using System;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");
            list.RemoveRandomElement();
            list.RemoveRandomElement();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list.RandomString());
            }

            var myStack = new StackOfStrings();
            Console.WriteLine(myStack.IsEmpty());
            myStack.AddRange(list);
            Console.WriteLine(myStack.IsEmpty());
        }
    }
}
