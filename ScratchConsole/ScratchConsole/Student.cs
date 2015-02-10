using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchConsole
{
    public class Student
    {
        private static int nextId = 1;
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        //AGE - should be get only; use Birthdate to derive the value
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - Birthdate.Year;
                if (DateTime.Now.Month < Birthdate.Month ||
                    (DateTime.Now.Month == Birthdate.Month && DateTime.Now.Day < Birthdate.Day))
                {
                    age--;
                }

                return age;
            }
        }

        public Student()
        {
            StudentId = nextId++;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Birthdate.ToShortDateString());
        }
    }
}
