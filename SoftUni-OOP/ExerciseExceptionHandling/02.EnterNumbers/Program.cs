using System;

namespace _02.EnterNumbers
{
    public class Program
    {

        public static bool ReadNumbers(int start, int end)
        {
            if (start < 0 || end > 10)
            {
                return true;
            }
            return false;
        }
        public static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    int number = int.Parse(Console.ReadLine());

                    if (ReadNumbers(number, number))
                    {
                        throw new ArgumentOutOfRangeException("The number should be in range 0-10.");

                        i = 0;
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
