using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.interfaces
{
    public interface  IMission
    {
        string CodeName { get; }
        string State { get; }

        void CompleteMission();
    }
}
