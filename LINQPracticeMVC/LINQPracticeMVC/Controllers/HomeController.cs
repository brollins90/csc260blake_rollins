using LINQPracticeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LINQPracticeMVC.Controllers
{
    public class HomeController : Controller
    {
        private static List<Student> students;

        private void BuildList()
        {
            students = new List<Student>();
            students.Add(new Student()
            {
                Birthdate = new DateTime(1995, 8, 5),
                FirstName = "Scott",
                ID = 1,
                LastName = "Puckett",
                Sex = Gender.Male
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(1990, 4, 19),
                FirstName = "Blake",
                ID = 2,
                LastName = "Rollins",
                Sex = Gender.Male
            });

            students.Add(new Student()
            {
                Birthdate = new DateTime(2000, 5, 12),
                FirstName = "John",
                ID = 3,
                LastName = "Smith",
                Sex = Gender.Male
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(1994, 6, 24),
                FirstName = "Emma",
                ID = 4,
                LastName = "Johnson",
                Sex = Gender.Female
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(1980, 7, 16),
                FirstName = "James",
                ID = 5,
                LastName = "Bond",
                Sex = Gender.Male
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(1998, 8, 1),
                FirstName = "Karrissa",
                ID = 6,
                LastName = "Faux",
                Sex = Gender.Female
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(1996, 9, 30),
                FirstName = "Josh",
                ID = 7,
                LastName = "Thompson",
                Sex = Gender.Male
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(1992, 10, 4),
                FirstName = "Sam",
                ID = 8,
                LastName = "Baker",
                Sex = Gender.Female
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(1992, 11, 19),
                FirstName = "Todd",
                ID = 9,
                LastName = "Clark",
                Sex = Gender.Male
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(1992, 11, 19),
                FirstName = "Susan",
                ID = 10,
                LastName = "Clark",
                Sex = Gender.Female
            });
        }

        public HomeController()
        {
            if (students == null)
            {
                BuildList();
            }
        }

        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<Student> s = students.OrderBy(x => x.FirstName).OrderBy(x => x.LastName);
            return View("List", s);
        }

        public ActionResult Female()
        {
            IEnumerable<Student> s = students.Where(x => x.Sex == Gender.Female).OrderBy(x => x.LastName);
            return View("List", s);
        }

        public ActionResult Adults()
        {
            IEnumerable<Student> s = students.Where(x => x.Age >= 18).OrderBy(x => x.LastName).OrderByDescending(x => x.Age);
            return View("List", s);
        }

        public ActionResult LastFirst()
        {
            IEnumerable<Student> s = students.OrderByDescending(x => x.FirstName).OrderBy(x => x.LastName);
            return View("List", s);
        }
        
        public ActionResult One(int id)
        {
            IEnumerable<Student> s = students.Where(x => x.ID % id == 0);
            return View("List", s);
        }
    }
}