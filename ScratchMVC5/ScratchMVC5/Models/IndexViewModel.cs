using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchMVC5.Models
{
    public class IndexViewModel
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public int Id { get; set; }

        public IndexViewModel()
        {
            Action = "UNKNOWN";
            Controller = "UNKNOWN";
            Id = -1337;
        }
    }
}