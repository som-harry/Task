using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarryStoreApp.Models
{
    public class Min400IfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.BalanceInAccount == null)
                return new ValidationResult("Deposit is required");

            var amount = customer.BalanceInAccount.Value;
            return (amount >= 400)
                ? ValidationResult.Success
                : new ValidationResult("Customer should deposit 400 up");
            
        }
    }
}