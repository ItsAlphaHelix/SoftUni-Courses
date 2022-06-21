using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    class RandomList : List<string>
    {

        private Random random;

        public RandomList()
        {
            random = new Random();
        }

        public string RandomString()
        {
            var index = random.Next(0, Count);
            return this[index];
        }

        public void RemoveRandomElement()
        {
            var index = random.Next(0, Count);
            RemoveAt(index);
        }
    }
}
