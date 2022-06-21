using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string type, string name)
            : base(type, name)
        {

        }

        public override int AbilityPower
            => base.AbilityPower + 100;
        public override string CastAbility()
        {
            return $"{this.Type} - {this.Name} hit for {this.AbilityPower} damage";
        }
    }
}
