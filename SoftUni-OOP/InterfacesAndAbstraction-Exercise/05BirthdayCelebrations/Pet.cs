using System;
using System.Collections.Generic;
using System.Text;

namespace _05BirthdayCelebrations
{
    public class Pet : IIdentifiable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}
