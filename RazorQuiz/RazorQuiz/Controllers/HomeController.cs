using RazorQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;

namespace RazorQuiz.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string vehicleType)
        {
            Vehicle v = null;
            //try
            //{
            //    ObjectHandle ohandle = Activator.CreateInstance(null, "RazorQuiz.Models." + vehicleType);

            //    v = (Vehicle)ohandle.Unwrap();
            //}
            //catch (Exception)
            //{

            //}

            if (string.IsNullOrEmpty(vehicleType))
            {
                // null still
            }
            else if (vehicleType.ToLower().Equals("car"))
            {
                v = new Car();
            }
            else if (vehicleType.ToLower().Equals("boat"))
            {
                v = new Boat();
            }
            else if (vehicleType.ToLower().Equals("spaceship"))
            {
                v = new Spaceship();
            }
            else
            {
                // null still
            }

            return View(v);
        }
    }
}