using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> indices = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    indices.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int opentBracketIndex = indices.Pop();
                    int closedBracketIndex = i;

                    Console.WriteLine(expression.Substring(opentBracketIndex, 
                        closedBracketIndex - opentBracketIndex + 1));
                }
            }
        }
    }
}
