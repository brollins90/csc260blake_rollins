using System;
using SocialSiteV4.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using SocialSiteV4_2.Dal;
using SocialSiteV4_2.Infrastructure;
using SocialSiteV4_2.Models;

namespace SocialSiteV4_2.Controllers
{
    public class ProfileController : Controller
    {
        //private readonly SocialDBContext _context = new SocialDBContext();
        private readonly IDal _dal = new Dal.Dal();

        public ProfileController()
        {
        }

        // GET: Profile
        [AllowAnonymous]
        public ActionResult Index(string id)
        {
            int profileId = GetProfileId(id);
            Profile profileForViewing = _dal.GetProfile(profileId) ?? _dal.GetRandomProfile();

            if (profileForViewing != null)
            {
                //ViewBag.Title = profileForViewing.User.UserName + "'s Profile";

                if (User.Identity.IsAuthenticated)
                {
                    Profile myProfile = _dal.GetProfile(GetMyId());
                    if (profileForViewing.Id == myProfile.Id || User.IsInRole("Administrator"))
                        ViewBag.Edit = "true";
                }
            }
            return View("Index", profileForViewing);
        }

        // GET: Profile
        [AllowAnonymous]
        public ActionResult Profiles()
        {
            IEnumerable<Profile> profiles = _dal.GetProfileList();
            return View("Profiles", profiles);
        }

        [AuthorizeSelfAnd(Roles = "Administrator")]
        public ActionResult Edit(string id)
        {
            int profileId = GetProfileId(id);
            Profile profileForViewing = _dal.GetProfile(profileId);
            return View("ProfileForm", profileForViewing);
        }

        [HttpPost]
        [AuthorizeSelfAnd(Roles = "Administrator")]
        public ActionResult Edit(Profile p)
        {
            if (ModelState.IsValid)
            {
                _dal.UpdateProfile(p);
                return RedirectToAction("Index", new { id = p.Id });
            }

            return View("ProfileForm", p);
        }

        [AllowAnonymous]
        public ActionResult Gallery(string id)
        {

            ViewBag.ImageRelativePath = "/Content/Images/";
            ViewBag.ImagePath = HostingEnvironment.MapPath("~" + ViewBag.ImageRelativePath);

            int profileId = GetProfileId(id);
            Profile p = _dal.GetProfile(profileId);

            GalleryViewModel gvm = new GalleryViewModel();
            if (p == null)
            {
                return View("Gallery", gvm);
            }

            //ViewBag.Title = p.User.UserName + "'s Gallery";

            //gvm.Name = p.User.UserName;
            gvm.Images = new List<string>();

            try
            {
                DirectoryInfo di = new DirectoryInfo(ViewBag.ImagePath + p.Id);
                FileInfo[] images = di.GetFiles();
                foreach (var f in images)
                {
                    gvm.Images.Add(ViewBag.ImageRelativePath + p.Id + "/" + f.Name);
                }
            }
            catch (Exception)
            {
                
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
            string id =
                (User.Identity.IsAuthenticated)
                ? _dal.GetUserByUsername(User.Identity.Name).Profile.Id.ToString()
                : "-1";
            return int.Parse(id);
        }
    }
}