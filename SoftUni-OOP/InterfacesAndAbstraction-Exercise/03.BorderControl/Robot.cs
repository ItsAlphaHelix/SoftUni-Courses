using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Robot : Identifiable
    {
        public Robot(string id, string model)
        {
           this.Id = id;
           this.Model = model;
        }

        public string Id { get; }
        public string Model { get; set; }
    }
}
