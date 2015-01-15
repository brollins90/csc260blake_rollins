using ScratchMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScratchMVC5.Controllers
{
    public class MembershipController : Controller
    {
        // GET: Membership
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel ivm)
        {
            return View();
        }
    }
}