using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> parentheses = new Stack<char>();

            bool isBlanced = true;

            foreach (var symbol in input)
            {
                if (symbol == '{' || symbol == '[' || symbol == '(')
                {
                    parentheses.Push(symbol);
                }
                else
                {
                    if (parentheses.Count == 0)
                    {
                        isBlanced = false;
                        break;
                    }

                    bool isValid = (symbol == '}' && parentheses.Peek() == '{')
                        || (symbol == ']' && parentheses.Peek() == '[')
                        || (symbol == ')' && parentheses.Peek() == '(');

                    if (isValid)
                    {
                        parentheses.Pop();
                    }
                    else
                    {
                        isBlanced = false;
                        break;
                    }
                }
            }
            if (isBlanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
