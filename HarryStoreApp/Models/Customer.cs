using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HarryStoreApp.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } 
        public int MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public decimal? BalanceInAccount { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}