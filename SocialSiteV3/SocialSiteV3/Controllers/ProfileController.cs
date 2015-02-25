using SocialSiteV3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace SocialSiteV3.Controllers
{
    public class ProfileController : Controller
    {
        Profile p;

        public ProfileController()
        {
            p = new Profile();
            p.Name = "Blake Rollins";
            p.ImageUrl = "/Content/Images/blake/10922490_797414246961859_6987115947949819923_n.jpg";
            p.ImageRelativePath = "/Content/Images/blake/";
            p.ImagePath = HostingEnvironment.MapPath("~" + p.ImageRelativePath);
            p.Favorites = new Dictionary<string, string>();
            p.Favorites.Add("Book", "Game of Thrones (George R R Martin)");
            p.Favorites.Add("Movie", "Dogma (Kevin Smith)");
            p.Favorites.Add("Food", "Shrimp fetuccini alfredo");
        }

        // GET: Profile
        public ActionResult Index()
        {
            p.Layout = "_LayoutDark.cshtml";
            return View("Index", p);
        }

        public ActionResult Gallery()
        {
            GalleryViewModel gvm = new GalleryViewModel();
            gvm.Name = p.Name;
            gvm.Images = new List<string>();

            DirectoryInfo di = new DirectoryInfo(p.ImagePath);
            FileInfo[] images = di.GetFiles();
            foreach (var f in images)
            {
                gvm.Images.Add(p.ImageRelativePath + f.Name);
            }
            return View(gvm);
        }
    }
}