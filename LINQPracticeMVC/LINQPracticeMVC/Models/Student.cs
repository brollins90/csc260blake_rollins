using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LINQPracticeMVC.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
        public DateTime Birthdate { get; set; }
        public Gender Sex { get; set; }
    }
}