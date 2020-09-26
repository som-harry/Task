using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarryStoreApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Deposit to get Discount")]
        [Min400IfAMember]
        public decimal? BalanceInAccount { get; set; }
    }
}