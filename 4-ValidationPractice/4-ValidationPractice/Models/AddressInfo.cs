using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _4_ValidationPractice.Models
{
    public class AddressInfo : IValidatableObject
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Street) &&
                (!string.IsNullOrEmpty(City) ||
                !string.IsNullOrEmpty(State) ||
                !string.IsNullOrEmpty(Zip)))
            {
                errors.Add(new ValidationResult("The Street cannot be empty since some of the address is populated", new string[] { "Street" }));
            }

            if (string.IsNullOrEmpty(City) &&
                (!string.IsNullOrEmpty(Street) ||
                !string.IsNullOrEmpty(State) ||
                !string.IsNullOrEmpty(Zip)))
            {
                errors.Add(new ValidationResult("The City cannot be empty since some of the address is populated", new string[] { "City" }));
            }

            if (string.IsNullOrEmpty(State) &&
                (!string.IsNullOrEmpty(City) ||
                !string.IsNullOrEmpty(Street) ||
                !string.IsNullOrEmpty(Zip)))
            {
                errors.Add(new ValidationResult("The State cannot be empty since some of the address is populated", new string[] { "State" }));
            }

            if (string.IsNullOrEmpty(Zip) &&
                (!string.IsNullOrEmpty(City) ||
                !string.IsNullOrEmpty(State) ||
                !string.IsNullOrEmpty(Street)))
            {
                errors.Add(new ValidationResult("The Zip cannot be empty since some of the address is populated", new string[] { "Zip" }));
            }

            return errors;
        }
    }
}