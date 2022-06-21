using System;

namespace ImplementCustomStack
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            Stack<string> stack = new Stack<string>();

            stack.Push("Mitachi");
            stack.Push("Ivancho");
            stack.Pop();

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}