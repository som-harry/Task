using HarryStoreApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarryStoreApp.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public int Id { get; set; }

        [Required]
        [Display(Name ="Your full name")]
        public string Name { get; set; }

        [Required]
        public bool IsSubscribedToNewsLetter { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }


        [Display(Name = "Deposit to get Discount")]
        //[Min400IfAMember]
        public decimal? BalanceInAccount { get; set; }

        [Required(ErrorMessage = "Please enter a valid password")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please enter a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password enter a valid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password cannot be null")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Mismatch")]
        public string ConfirmPassword { get; set; }

        public CustomerFormViewModel()
        {
            Id = 0;
        }


        public CustomerFormViewModel(Customer customer)
        {
            Name = customer.Name;
            BalanceInAccount = customer.BalanceInAccount;
            IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            Id = customer.Id;

        }

    }
}