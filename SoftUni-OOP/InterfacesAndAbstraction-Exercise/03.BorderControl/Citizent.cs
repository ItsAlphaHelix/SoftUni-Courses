using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Citizent : Identifiable
    {
        public Citizent(string id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public string Id { get; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
