using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public interface ISmartPhone
    {
        public void Calling(string number);

        public void Browser(string number);
    }
}
