using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero : IBaseHero
    {
        private string type;
        protected BaseHero(string type, string name)
        {
            this.Type = type;
            this.Name = name;
        }

        public string Type
        {
            get
            { 
                return type;
            }
            private set
            {
                type = value;
            }
        }

        public string Name { get; private set; }

        public virtual int AbilityPower { get; private set; }

        public abstract string CastAbility();
    }
}
