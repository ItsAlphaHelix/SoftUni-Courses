using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            Stack<string> stringStates = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ');

                string action = commandArgs[0];

                if (action == "1")
                {
                    stringStates.Push(sb.ToString());
                    string currentString = commandArgs[1];
                    sb.Append(currentString);
                }
                else if (action == "2")
                {
                    stringStates.Push(sb.ToString());
                    int count = int.Parse(commandArgs[1]);

                    while (count > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        count--;
                    }
                }
                else if (action == "3")
                {
                    int element = int.Parse(commandArgs[1]);
                    Console.WriteLine(sb[element - 1]);
                }
                else
                {
                    sb.Clear();
                    sb.Append(stringStates.Pop());
                }
            }
        }
    }
}
