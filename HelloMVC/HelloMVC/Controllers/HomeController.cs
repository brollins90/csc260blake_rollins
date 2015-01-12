using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloMVC.Models;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {
        Random rand = new Random();

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            Blake b = new Blake();
            b.Name = "Blake Rollins";
            b.School = "Neumont University";
            b.Hobbies = new List<string>();
            b.Hobbies.Add("Cycling");
            b.Hobbies.Add("Eating");
            b.Hobbies.Add("Starcraft");
            b.Movies = new List<string>();
            b.Movies.Add("Air Force One");
            b.Movies.Add("Clerks");
            b.Movies.Add("Dogma");

            ViewBag.Hobby = b.Hobbies.ElementAt(rand.Next(b.Hobbies.Count));
            ViewBag.Movie = b.Movies.ElementAt(rand.Next(b.Movies.Count));
            return View(b);
        }

        [HttpGet]
        public ActionResult CollectUserInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CollectUserInfo(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                return View("CollectedUserInfo", userInfo);
            }
            else
            {
                return View();
            }
        }
    }
}