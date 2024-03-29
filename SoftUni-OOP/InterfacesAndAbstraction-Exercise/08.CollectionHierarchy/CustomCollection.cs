﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
        public class CustomCollection : IAdd
        {
            public CustomCollection()
            {
                this.Data = new List<string>(100);
            }
            public IList<string> Data { get; private set; }

            public virtual int Add(string item)
            {
                var index = 0;
                this.Data.Insert(index, item);

                return index;
            }
        }
}
