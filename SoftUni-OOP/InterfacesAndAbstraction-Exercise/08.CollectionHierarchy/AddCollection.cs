using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class AddCollection : CustomCollection
    {
        public override int Add(string item)
        {
            base.Data.Add(item);

            return this.Data.Count - 1;
        }
    }
}
