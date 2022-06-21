using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCaloriesV
{
    public class Dough
    {
        private const string DoughMessage = "Invalid type of dough.";
        private const string WeightMessage = "Dough weight should be in the range [1..200].";

        Dictionary<string, double> flourTypeCalories = new Dictionary<string, double>()
        {
            {"white", 1.5},
            {"wholegrain", 1.0}
        };

        Dictionary<string, double> bakingTechniqueCalories = new Dictionary<string, double>()
        {
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1.0}
        };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return flourType; }
            private set 
            {
                if (!flourTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(DoughMessage);
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (!bakingTechniqueCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(DoughMessage);
                }
                bakingTechnique = value; 
            }
        }

        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(WeightMessage);
                }
                weight = value;
            }
        }

        public double doughCalories
            => 2 * this.Weight * flourTypeCalories[this.flourType.ToLower()]
            * bakingTechniqueCalories[this.bakingTechnique.ToLower()];
    }
}
