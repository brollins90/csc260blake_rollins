using _4_ValidationPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4_ValidationPractice.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
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