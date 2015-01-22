using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorQuiz.Models
{
    public class Car : Vehicle
    {
        public Car()
        {
            this.Noun = "car";
            this.Verb = "drove";
        }
    }
}