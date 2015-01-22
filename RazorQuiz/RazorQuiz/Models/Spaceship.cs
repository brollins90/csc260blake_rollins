using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorQuiz.Models
{
    public class Spaceship : Vehicle
    {
        public Spaceship()
        {
            this.Noun = "spaceship";
            this.Verb = "flew";
        }
    }
}