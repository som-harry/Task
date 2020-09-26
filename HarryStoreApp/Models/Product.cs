using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HarryStoreApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

  
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int Quatity { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime? DateToExpire { get; set; }

        public int NumberInStock { get; set; }

        public int? NumberAvailable { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}