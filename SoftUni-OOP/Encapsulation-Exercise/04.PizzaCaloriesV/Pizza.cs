﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCaloriesV
{
    public class Pizza
    {
        private string name;

        private Dough dough;

        private List<Topping> toppings;
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;

            toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public Dough Dough
        {
            get { return dough; }
            private set { dough = value; }
        }

        public IReadOnlyCollection<Topping> Toppings
            => this.toppings;

        public double CalculateSummingOfCalories
            => this.Dough.doughCalories + toppings.Sum(x => x.toppingCalories);

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }
    }
}
