using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<Movie> movies = null;
            using(MovieDBContext context = new MovieDBContext()) 
            {
                movies = context.Movies.ToList();
            }
            return View(movies);
        }
    }
}