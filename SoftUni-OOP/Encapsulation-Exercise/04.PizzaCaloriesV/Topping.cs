using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCaloriesV
{
    public class Topping
    {
        private string toppingType;
        private double weight;

        Dictionary<string, double> toppingTypeCalories = new Dictionary<string, double>()
        {
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9}
        };
        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get { return toppingType; }
            private set 
            {
                if (!toppingTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
            }
        }


        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($" {this.ToppingType} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double toppingCalories
            => 2 * this.Weight * toppingTypeCalories[this.toppingType.ToLower()];
    }
}
