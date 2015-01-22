using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorQuiz.Models
{
    public class Boat : Vehicle
    {
        public Boat()
        {
            this.Noun = "boat";
            this.Verb = "sailed";
        }
    }
}