using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class MyList : AddRemoveCollection, IMyList
    {
        public int Used => base.Data.Count;

        public override string Remove()
        {
            string element = base.Data.First();
            base.Data.Remove(element);

            return element;
        }
    }
}
