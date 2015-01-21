using _3_Routing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3_Routing.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(CowViewModel cow)
        {
            CowViewModel c = cow ?? new CowViewModel();
            return View(c);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Gallery(CowViewModel cow)
        {
            CowViewModel c = cow ?? new CowViewModel();
            return View(c);
        }

        public ActionResult AllGallery(string perPage, string pageNum)
        {
            ViewBag.perPage = perPage;
            ViewBag.pageNum = pageNum;
            return View();
        }

        public ActionResult JustMoo(JustMooViewModel justMoo)
        {
            JustMooViewModel vm = justMoo ?? new JustMooViewModel();
            return View(vm);
        }

        public ActionResult Moo(CowViewModel cow)
        {
            CowViewModel c = cow ?? new CowViewModel();
            return View(c);
        }

        public ActionResult Redir(string page)
        {
            return Redirect(page);
        }
    }
}