using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _4_ValidationPractice.Models
{
    public class UserInfo
    {
        [Required(ErrorMessage = "You need to enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need to enter your age")]
        [Range(5, int.MaxValue, ErrorMessage = "You cannot use this form if you are younger than 5")]
        public int? Age { get; set; }

        public AddressInfo Address { get; set; }
    }
}