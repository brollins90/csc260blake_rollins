//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;

//namespace _4_ValidationPractice.Models
//{
//    public class UserAddressValidator : ValidationAttribute
//    {
//        public UserAddressValidator()
//        {
//            ErrorMessage = "All the fields must be complete or no field should have a value";
//        }

//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            AddressInfo address = value as AddressInfo;

//            string[] memberNames = new string[] { "City", "State", "Zip" };


//            //if (address == null)
//            //{
//            //    return false;
//            //}
//            //else 
//            if (
//            string.IsNullOrEmpty(address.City) &&
//            string.IsNullOrEmpty(address.Street) &&
//            string.IsNullOrEmpty(address.State) &&
//            string.IsNullOrEmpty(address.Zip))
//            {
//                return ValidationResult.Success;
//            }
//            else if (
//                !string.IsNullOrEmpty(address.City) &&
//              !string.IsNullOrEmpty(address.Street) &&
//              !string.IsNullOrEmpty(address.State) &&
//              !string.IsNullOrEmpty(address.Zip))
//            {
//                return ValidationResult.Success;
//            }
//            return new ValidationResult(ErrorMessage, memberNames);
//        }
//    }
//}