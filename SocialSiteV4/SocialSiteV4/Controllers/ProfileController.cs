using SocialSiteV4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace SocialSiteV4.Controllers
{
    public class ProfileController : Controller
    {
        SocialDBContext context = new SocialDBContext();

        public ProfileController()
        {
            //p = new Profile();
            //p.Id = 100;
            //p.Name = "Blake Rollins";
            //p.ImageUrl = "/Content/Images/" + p.Id + "/10922490_797414246961859_6987115947949819923_n.jpg";
            //p.ImageRelativePath = "/Content/Images/" + p.Id + "/";
            //p.ImagePath = HostingEnvironment.MapPath("~" + p.ImageRelativePath);
            //p.Favorites = new Dictionary<string, string>();
            //p.Favorites.Add("Book", "Game of Thrones (George R R Martin)");
            //p.Favorites.Add("Movie", "Dogma (Kevin Smith)");
            //p.Favorites.Add("Food", "Shrimp fetuccini alfredo");
        }

        // GET: Profile
        public ActionResult Index(string id)
        {

            if (string.IsNullOrEmpty(id) || id.ToLower().Equals("index")) {
                if (User.Identity.IsAuthenticated)
                {
                    id = (context.AspNetUsers.Where(x => x.UserName.Equals(User.Identity.Name)).First()).Profile.Id.ToString();
                }
                else
                {
                    id = "-1";
                }
            }

            int idInt = int.Parse(id);
            Profile p = context.Profiles.Where(x => x.Id == idInt).FirstOrDefault();
            if (p != null)
            {
                ViewBag.Title = p.AspNetUser.UserName + "'s Profile";
            }
            return View("Index", p);
        }

        public ActionResult Gallery(string id)
        {
            ViewBag.ImageRelativePath = "/Content/Images/";
            ViewBag.ImagePath = HostingEnvironment.MapPath("~" + ViewBag.ImageRelativePath);

            if (string.IsNullOrEmpty(id) || id.ToLower().Equals("index"))
            {
                if (User.Identity.IsAuthenticated)
                {
                    id = (context.AspNetUsers.Where(x => x.UserName.Equals(User.Identity.Name)).First()).Profile.Id.ToString();
                }
                else
                {
                    id = "-1";
                }
            }

            int idInt = int.Parse(id);
            Profile p = context.Profiles.Where(x => x.Id == idInt).FirstOrDefault();

            GalleryViewModel gvm = new GalleryViewModel();
            if (p == null)
            {
                return View("Gallery", gvm);
            } 

            ViewBag.Title = p.AspNetUser.UserName + "'s Gallery";

            gvm.Name = p.AspNetUser.UserName;
            gvm.Images = new List<string>();

            DirectoryInfo di = new DirectoryInfo(ViewBag.ImagePath);
            FileInfo[] images = di.GetFiles();
            foreach (var f in images)
            {
                gvm.Images.Add(ViewBag.ImageRelativePath + f.Name);
            }
            return View(gvm);
        }
    }
}