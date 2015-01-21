using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_Routing.Models
{
    public class CowViewModel
    {

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int? _numberOfMoos;

        public int? NumberOfMoos
        {
            get { return _numberOfMoos; }
            set { _numberOfMoos = value; }
        }

        public CowViewModel()
        {
            this.Name = "Default Cow";
            this.NumberOfMoos = 0;
        }
    }
}