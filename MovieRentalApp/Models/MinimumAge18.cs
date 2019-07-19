using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
    public class MinimumAge18 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.Dob == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.Dob.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Age must be 18 years or more to avail membership");

            return base.IsValid(value, validationContext);
        }
    }
}