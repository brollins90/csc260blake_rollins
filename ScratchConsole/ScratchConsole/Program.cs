using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        public void Run()
        {
            List<Student> students = new List<Student>()
                {
                    new Student() {
                        Name = "Sally", Birthdate = new DateTime(1990, 02, 05)},
                    new Student() {
                        Name = "Sue", Birthdate = new DateTime(1995, 03, 19)},
                    new Student() {
                        Name = "Thom", Birthdate = new DateTime(1756, 1, 1)},
                    new Student() {
                        Name = "future", Birthdate = new DateTime(2025, 12, 18)},
                    new Student() {
                        Name = "Star Wars", Birthdate = new DateTime(1977, 5, 7)},
                };

            Console.WriteLine(students.Print());

            var bornInFebruary = students.Where(x => x.Birthdate.Month == 2);
            Console.WriteLine(bornInFebruary.Print() + "\n");
            

            var nameAgePairs = students.Select(s => new { Name = s.Name, Age = (int)((DateTime.Now - s.Birthdate).Days / 365.25)});
            Console.WriteLine(nameAgePairs.Print() + "\n");


            var ageCounts = students.GroupBy(n => n.Age).ToDictionary(x => x.Key, x => x.Count());
            Console.WriteLine(ageCounts.Print() + "\n");


        }

        //public void Go()
        //{
        //    int[] nums = new int[] { 1, 2, 3, 4, 5 };

        //    // LINQ w/ sugar
        //    var n1 = nums.Where(i => i % 2 == 0).OrderBy(x => x);
        //    Console.WriteLine("n1: {0}", n1.Print());


        //    // without sugar
        //    var n2 = from x in nums
        //            where x % 2 == 0
        //            orderby x
        //             select x;
        //    Console.WriteLine("n2: {0}", BExtensions.Print(n2));


        //    // with no sugar
        //    IEnumerable<int> n3 = Enumerable.OrderBy(Enumerable.Where(nums, BExtensions.Where2), BExtensions.OrderBy2);
        //    Console.WriteLine("n3: {0}", BExtensions.Print(n3));

        //    Console.WriteLine("Press any key to continue");
        //    Console.ReadKey();
        //}

    }
}
