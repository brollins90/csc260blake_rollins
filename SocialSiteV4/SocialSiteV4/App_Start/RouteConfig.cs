using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SocialSiteV4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Profile1",
            //    url: "Profile/{id}",
            //    defaults: new { controller = "Profile", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Profilegal",
            //    url: "Profile/Gallery/{id}",
            //    defaults: new { controller = "Profile", action = "Gallery", id = UrlParameter.Optional }
            //);
        }
    }
}
