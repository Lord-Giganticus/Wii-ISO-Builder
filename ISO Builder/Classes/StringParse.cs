using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISO_Builder.Classes
{
    static class StringParse
    {
        public static int ContainsAnyCase(this string haystack, char needle)
        {
            return haystack.IndexOf(needle, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}