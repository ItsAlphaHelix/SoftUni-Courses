using System;

namespace _03.Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekDays = new string[5];

            weekDays[0] = "Sunday";
            weekDays[1] = "Monday";
            weekDays[2] = "Tuesday";
            weekDays[3] = "Wednesday";
            weekDays[4] = "Thursday";

            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekDays[i].ToString());

                    if (i >= 5)
                    {
                        throw new IndexOutOfRangeException("The index should in range 0-4");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
