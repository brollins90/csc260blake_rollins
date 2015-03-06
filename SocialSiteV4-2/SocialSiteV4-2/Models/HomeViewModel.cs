using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialSiteV4_2.Models
{
    public class HomeViewModel
    {
        public string Welcome { get; set; }
        public List<News> Newses { get; set; }
    }
}