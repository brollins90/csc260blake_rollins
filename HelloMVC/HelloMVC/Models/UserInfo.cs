using System;
using System.ComponentModel.DataAnnotations;

namespace HelloMVC.Models
{
    public class UserInfo
    {
        [Required(ErrorMessage = "You need to enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage="Please enter your favorite movie")]
        public string Movie { get; set; }

        [Required(ErrorMessage = "Please enter your age")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Please tell us where you are from")]
        public string Hometown { get; set; }

    }
}