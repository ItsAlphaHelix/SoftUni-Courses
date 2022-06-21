using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.interfaces
{
    public interface IRepair
    {
        string PartName { get; }
        int HoursWorked { get; }
    }
}
