using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _3_Routing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // www.cows.com should map to the homepage.
            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            // www.cows.com/EatMoreChicken should map to Chick-fill-a’s website.
            routes.MapRoute(
                name: "EatMoreChicken",
                url: "EatMoreChicken",
                defaults: new { controller = "Home", action = "Redir", page = "http://www.chick-fil-a.com/" }
            );

            // www.cows.com/Moo maps to the “About Us” page.
            routes.MapRoute(
                name: "About",
                url: "Moo",
                defaults: new { controller = "Home", action = "About" }
            );

            // www.cows.com/Moo8 maps to a page that says “moo” 8 times, however, the 8 is arbitrary.
            routes.MapRoute(
                name: "MooAndCount",
                url: "Moo{NumberOfMoos}",
                defaults: new { controller = "Home", action = "JustMoo" }
            );

            // www.cows.com/Betsy/Gallery maps to information about Betsy alone. Betsy is arbitrary and could be any cow name.
            routes.MapRoute(
                name: "AllCowsGallery",
                url: "AllCows/Gallery",
                defaults: new { controller = "Home", action = "AllGallery" }
            );

            // www.cows.com/AllCows/Gallery/Page5 maps to information about all the cows featured on our website, 5 per page, page 5. The page number is arbitrary.
            routes.MapRoute(
                name: "AllCowsGalleryCountPerPage",
                url: "AllCows/Gallery/Page{pageNum}",
                defaults: new { controller = "Home", action = "AllGallery", perPage = 5}
            );

            // www.cows.com/AllCows/Gallery/5/Page5 maps to information about all the cows featured on our website, 5 per page, page 5. Both values of 5 are arbitrary.
            routes.MapRoute(
                name: "AllCowsGalleryCount",
                url: "AllCows/Gallery/{perPage}/Page{pageNum}",
                defaults: new { controller = "Home", action = "AllGallery"}
            );

            // www.cows.com/AllCows/Gallery/5/6 maps to information about all the cows featured on our website, 5 per page, page 6. Both of the values 5 and 6 are arbitrary.
            routes.MapRoute(
                name: "AllCowsGalleryCountPerPageSimple",
                url: "AllCows/Gallery/{perPage}/{pageNum}",
                defaults: new { controller = "Home", action = "AllGallery", perPage = 5, pageNum = UrlParameter.Optional }
            );

            // www.cows.com/Betsy/Gallery maps to information about Betsy alone. Betsy is arbitrary and could be any cow name.
            routes.MapRoute(
                name: "CowGallery",
                url: "{Name}/Gallery/",
                defaults: new { controller = "Home", action = "Gallery"}
            );

            // www.cows.com/8 maps to a page that says “The cow Default Cow moos at you 8 times.” However the 8 is arbitrary, and can be any number.
            // www.cows.com/20/Betsy maps to a page that says “The cow Betsy moos at you 20 times.” However the 20 is arbitrary, and can be any number. The cow’s name is also arbitrary.
            routes.MapRoute(
                name: "CowAndMoo",
                url: "{NumberOfMoos}/{Name}",
                defaults: new { controller = "Home", action = "Moo", Name = UrlParameter.Optional }
            );






            

            // www.cows.com should map to the homepage.
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

            // Index{id}/{*stuff}


            



        }
    }
}
