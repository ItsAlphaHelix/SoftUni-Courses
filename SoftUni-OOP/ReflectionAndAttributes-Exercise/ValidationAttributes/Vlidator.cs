using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Vlidator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj
                .GetType()
                .GetProperties();

            foreach (var propertyInfo in properties)
            {
                var attributes = propertyInfo
                    .GetCustomAttributes()
                    .Where(t => t.GetType().IsSubclassOf(typeof(MyValidationAttribute)))
                    .ToArray();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    bool isValid = attribute.IsValid(propertyInfo.GetValue(obj));

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
