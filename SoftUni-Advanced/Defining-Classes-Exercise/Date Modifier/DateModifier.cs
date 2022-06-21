using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
   public static class DateModifier
    {
        public static int CaluclateDateDifferenceInDays(string firstDay, string secondDate)
        {
            DateTime dateOne = DateTime.Parse(firstDay);
            DateTime dateTwo = DateTime.Parse(secondDate);

            int days = Math.Abs((dateOne - dateTwo).Days);

            return days;
        }
    }
}
