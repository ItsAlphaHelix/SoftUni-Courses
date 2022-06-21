using System;
using System.Collections.Generic;
using System.Text;

namespace _05BirthdayCelebrations
{
    public class Robot
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Id { get; private set; }

        public string Model { get; set; }
    }
}
