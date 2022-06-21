using System;

namespace DateModifier
{
   public class Program
    {
       public static void Main(string[] args)
        {
            string firstDay = Console.ReadLine();
            string secondDay = Console.ReadLine();

            int days = DateModifier.CaluclateDateDifferenceInDays(firstDay, secondDay);

            Console.WriteLine(days);
        }
    }
}
