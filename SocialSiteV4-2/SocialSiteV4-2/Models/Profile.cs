﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SocialSiteV4_2.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public string ProfileImage { get; set; }
        public string Favorite1Title { get; set; }
        public string Favorite2Title { get; set; }
        public string Favorite3Title { get; set; }
        public string Favorite1Data { get; set; }
        public string Favorite2Data { get; set; }
        public string Favorite3Data { get; set; }

        public virtual ApplicationUser User { get; set; }

        public Profile()
        {
            ProfileImage = "/Content/Images/default.png";
            Favorite1Title = "Favorite Food";
            Favorite1Data = "Hamburger";
            Favorite2Title = "Favorite Song";
            Favorite2Data = "Crazy Train - Ozzy";
            Favorite3Title = "Favorite Movie";
            Favorite3Data = "Pokemon Movie";
        }
    }
}
