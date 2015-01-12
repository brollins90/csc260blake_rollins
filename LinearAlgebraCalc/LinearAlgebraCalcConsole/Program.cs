using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearAlgebraCalcLib;

namespace LinearAlgebraCalcConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            Vector2 v1 = new Vector2(new Fraction(1), new Fraction(1));
            Console.WriteLine("v1: {0}", v1);
            Vector2 v2 = new Vector2(new Fraction(2), new Fraction(2));
            Console.WriteLine("v2: {0}", v2);
            Vector2 v3 = v1 + v2;
            Console.WriteLine("v3: {0}", v3);

            
        }
    }
}
