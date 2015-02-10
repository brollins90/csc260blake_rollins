using PartialViewDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartialViewDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Dragon> drgns = new List<Dragon>
            {
                new Dragon{Name="Steve", Color="Red", Dogma="Murder", GoldCoins=12, Size=10},
                new Dragon{Name="Spyro", Color="Purple", Dogma="Gem Gathering", GoldCoins=100, Size=3},
                new Dragon{Name="Frank", Color="Yellow", Dogma="Christianity", GoldCoins=42, Size=4},
                new Dragon{Name="Trogdor", Color="Green", Dogma="Burnination", GoldCoins=400000000000, Size=5},
            };
            return View(drgns);
        }
    }
}