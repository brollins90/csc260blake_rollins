using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _4_ValidationPractice.Models
{
    public class UserAddressValidator : ValidationAttribute
    {
        public UserAddressValidator()
        {
            ErrorMessage = "All the fields must be complete or no field should have a value";
        }

        public override bool IsValid(object value)
        {
            AddressInfo address = value as AddressInfo;

            if (address == null)
            {
                return false;
            }
            else if (
                string.IsNullOrEmpty(address.City) &&
                string.IsNullOrEmpty(address.Street) &&
                string.IsNullOrEmpty(address.State) &&
                string.IsNullOrEmpty(address.Zip))
            {
                return true;
            }
            else if (
                !string.IsNullOrEmpty(address.City) &&
              !string.IsNullOrEmpty(address.Street) &&
              !string.IsNullOrEmpty(address.State) &&
              !string.IsNullOrEmpty(address.Zip))
            {
                return true;
            }
            return false;
        }
    }
}