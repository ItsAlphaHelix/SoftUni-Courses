using System;
using System.Collections.Generic;
using System.Text;

namespace _05BirthdayCelebrations
{
    public interface IIdentifiable
    {
        public string Name { get; set; }

        public string Birthdate { get; set; }
    }
}
