using SocialSiteV4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using SocialSiteV4.Dal;
using SocialSiteV4.Infrastructure;

namespace SocialSiteV4.Controllers
{
    public class ProfileController : Controller
    {
        private readonly SocialDBContext _context = new SocialDBContext();
        private readonly IDal _dal = new Dal.Dal();

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
        [AllowAnonymous]
        public ActionResult Index(string id)
        {
            int profileId = GetProfileId(id);
            Profile profileForViewing = _dal.GetProfile(profileId) ?? _dal.GetRandomProfile();

            if (profileForViewing != null)
            {
                ViewBag.Title = profileForViewing.AspNetUser.UserName + "'s Profile";

                if (User.Identity.IsAuthenticated)
                {
                    Profile myProfile = _dal.GetProfile(GetMyId());
                    if (profileForViewing.Id == myProfile.Id)
                        ViewBag.Edit = "true";
                }
            }
            return View("Index", profileForViewing);
        }

        [Authorize(Roles="Admin")]
        [AuthorizeTheUser]
        public ActionResult Edit(string id)
        {
            int profileId = GetProfileId(id);
            Profile profileForViewing = _dal.GetProfile(profileId);
            Profile myProfile = _dal.GetProfile(GetMyId());

            if (profileForViewing.Id == myProfile.Id)
            {
                return View("ProfileForm", profileForViewing);
            }
            else
            {
                // todo: make is a 403 error
                return new RedirectResult("Index");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [AuthorizeTheUser]
        public ActionResult Edit(Profile p)
        {
            if (ModelState.IsValid)
            {
                //_dal.UpdateProduct(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("ProfileForm", p);
            }
        }

        [AllowAnonymous]
        public ActionResult Gallery(string id)
        {
            if (IsMyProfile(id))
            {
                ViewBag.Edit = "true";
            }

            ViewBag.ImageRelativePath = "/Content/Images/";
            ViewBag.ImagePath = HostingEnvironment.MapPath("~" + ViewBag.ImageRelativePath);

            int profileId = GetProfileId(id);
            Profile p = _context.Profiles.FirstOrDefault(x => x.Id == profileId);

            GalleryViewModel gvm = new GalleryViewModel();
            if (p == null)
            {
                return View("Gallery", gvm);
            }

            ViewBag.Title = p.AspNetUser.UserName + "'s Gallery";

            gvm.Name = p.AspNetUser.UserName;
            gvm.Images = new List<string>();

            DirectoryInfo di = new DirectoryInfo(ViewBag.ImagePath + p.Id);
            FileInfo[] images = di.GetFiles();
            foreach (var f in images)
            {
                gvm.Images.Add(ViewBag.ImageRelativePath + p.Id + "/" + f.Name);
            }
            return View(gvm);
        }

        private int GetProfileId(string id)
        {
            // if the id is null or it is the work index (because of routing)
            if (string.IsNullOrEmpty(id) || id.ToLower().Equals("index"))
            {
                return GetMyId();
            }

            // else just parse the id to an int
            return int.Parse(id);
        }

        private int GetMyId()
        {
            string id = (User.Identity.IsAuthenticated)
                ? (_context.AspNetUsers.First(x => x.UserName.Equals(User.Identity.Name))).Profile.Id.ToString()
                : "-1";
            return int.Parse(id);
        }

        private bool IsMyProfile(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    // assume it is my page???
                }
                return
                    ((_context.AspNetUsers.First(x => x.UserName.Equals(User.Identity.Name))).Profile.Id.ToString()
                        .ToLower()
                        .Equals(id.ToLower()));
            }
            else
            {
                return false;
            }
        }
    }
}