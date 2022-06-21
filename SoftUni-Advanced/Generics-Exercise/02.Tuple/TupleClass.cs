using System;
using System.Collections.Generic;
using System.Text;

namespace Tuples
{
    public class TupleClass<itemOne, itemTwo, itemThree>
    {
        public TupleClass(itemOne firstItem, itemTwo secondItem, itemThree thirdItem)
        {
            FirstItem = firstItem;

            SecondItem = secondItem;

            ThirdItem = thirdItem;
        }

        public itemOne FirstItem { get; set; }
        public itemTwo SecondItem { get; set; }
        public itemThree ThirdItem { get; set; }

        public string GetItems()
        {
            return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
        }
    }
}
