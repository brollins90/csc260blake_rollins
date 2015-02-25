using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialSiteV2.Models
{
    public class Profile
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string ImagePath { get; set; }
        public string ImageRelativePath { get; set; }
        public Dictionary<string,string> Favorites { get; set; }
    }
}