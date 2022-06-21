using _07.MilitaryElite.implements;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.interfaces
{
    public interface ICommando
    {
        IList<Mission> Missions { get; }
    }
}
