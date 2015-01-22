using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchMVC5.Models
{
    public class Car : Quiz
    {
        public Car()
        {
            this.Verb = "Drove";
            this.Noun = "Car";
        }
    }
}