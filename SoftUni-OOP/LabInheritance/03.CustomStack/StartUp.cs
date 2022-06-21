using System;

namespace CustomStack
{
    public class StartUP
    {
        public static void Main(string[] args)
        {
            var myStack = new StackOfStrings();
            Console.WriteLine(myStack.IsEmpty());
            myStack.AddRange(myStack);
            Console.WriteLine(myStack.IsEmpty());
        }
    }
}
