using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4_ValidationPractice.Models
{
    [UserAddressValidator]
    public class AddressInfo
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }
}