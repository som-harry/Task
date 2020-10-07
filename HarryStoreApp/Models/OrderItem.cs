using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HarryStoreApp.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int productId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public int? CartId { get; set; }
        public Cart Cart { get; set; }
    }
}