﻿using SocialSiteV4.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SocialSiteV4.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            hvm.Welcome = "<p>Welcome to bSocial, the newest and bestest social site of them all.  Here you can create a profile and image gallery to share with all of your friends.</p><p>Right now we are only creating profiles for invited guests, but check back soon and we will make you a profile too.</p>";
            hvm.Newses = new List<News>();
            hvm.Newses.Add(new News() { Title = "News for Jan 30, 2015", Article = "The first bSocial profile page has been added for Blake Rollins.  We are so excited to have this profile up." });
            hvm.Newses.Add(new News() { Title = "News for Jan 29, 2015", Article = "The new bSocial site has had its first pages written in static HTML.  This is the first step in the road to the next great social networking site!" });

            return View(hvm);
        }
    }
}