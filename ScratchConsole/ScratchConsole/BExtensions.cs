using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchConsole
{
    public static class BExtensions
    {

        public static string Print<T>(this IEnumerable<T> col)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var t in col)
            {
                sb.Append(t.ToString());
                sb.Append(",");
            }

            string retval = sb.ToString();
            return retval.Trim().Substring(0, retval.Length - 1);
        }

        public static bool Where2(int i)
        {
            return (i % 2 == 0);
        }

        public static int OrderBy2(int x)
        {
            return x;
        }
    }
}
