using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            //Console.WriteLine("a: " + "a".SUM());
            //Console.WriteLine("A: " + "A".SUM());
            //Console.WriteLine("Blake is sooooo coool: " + "Blake is sooooo coool".SUM());
            //Console.WriteLine("aaaaaaa: " + "aaaaaaa".SUM());

            List<int> l = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine(l.CSVCollection());

            List<int> randNums = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                randNums.Add(rand.Next(100));
            }

                Console.WriteLine(randNums.CSVCollection());
            IEnumerable<int> evens = randNums.GetEvens();
            Console.WriteLine(evens.CSVCollection());


        }
    }

    static class ExPractice
    {

        public static int SUM(this string theString)
        {
            int retVal = 0;

            foreach (char c in theString.ToCharArray())
            {
                retVal += (int)c;
            }
            return retVal;
        }

        public static string CSVCollection<T>(this IEnumerable<T> col)
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


        public static IEnumerable<int> GetEvens(this IEnumerable<int> col) {

            //var evenNums = from n in col
            //               where n % 2 == 0
            //               select n;

            return col.Where(x => (x % 2) == 0);
        }

        
    }
}
