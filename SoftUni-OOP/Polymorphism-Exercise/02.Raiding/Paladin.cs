using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string type, string name)
            : base(type, name)
        {

        }

        public override int AbilityPower
            => base.AbilityPower + 100;
        public override string CastAbility()
        {
            return $"{this.Type} - {this.Name} healed for {this.AbilityPower}";
        }
    }
}
