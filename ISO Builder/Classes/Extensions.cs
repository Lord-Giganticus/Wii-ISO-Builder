using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISO_Builder.Classes
{
    public static class Extensions
    {
        public static List<T> ToList<T>(this T[] array)
        {
            var ReturnList = new List<T>();
            foreach (var a in array)
            {
                ReturnList.Add(a);
            }
            return ReturnList;
        }
    }
}
