using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string type, string name)
            : base(type, name)
        {

        }

        public override int AbilityPower
            => base.AbilityPower + 80;
        public override string CastAbility()
        {
            return $"{this.Type} - {this.Name} hit for {this.AbilityPower} damage";
        }
    }
}
