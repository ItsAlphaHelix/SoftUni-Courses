﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
   public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public string Displacement { get; set; } = "n/a";
        public string Efficiency { get; set; } = "n/a";

        public override string ToString()
        {
            return $"{Model}:\n    Power: {Power}\n    Displacement: {Displacement}\n    Efficiency: {Efficiency}";
        }
    }
}
