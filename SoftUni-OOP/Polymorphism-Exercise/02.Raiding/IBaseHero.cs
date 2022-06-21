using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public interface IBaseHero
    {
        public string Type { get;}

        public string Name { get;}

        public int AbilityPower { get;}

        public string CastAbility();
    }
}
