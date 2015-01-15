using ScratchMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScratchMVC5.Controllers
{
    // http://localhost:9507/?controller=q&action=q

    public class HomeController : Controller
    {
        public ActionResult Index(IndexViewModel model, string c2, string action)
        {
            IndexViewModel ivm = model ?? new IndexViewModel();

            return View(ivm);
        }
    }
}