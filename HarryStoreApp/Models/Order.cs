using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HarryStoreApp.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateOrder { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }
    }
}