using System;
using System.Reflection;

namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Spy spy = new Spy();
                string className = typeof(Hacker).FullName;
                string result = spy.RevealPrivateMethods(className);
                Console.WriteLine(result);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Value cannot be null!");
            }
        }
    }
}
