using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string type, string name)
            : base(type, name)
        {

        }

        public override int AbilityPower => 
            base.AbilityPower + 80;
        public override string CastAbility()
        {
            return $"{this.Type} - {this.Name} healed for {this.AbilityPower}";
        }
    }
}
