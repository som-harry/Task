using HarryStoreApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarryStoreApp.ViewModels
{
    public class ProductFormViewModel
    {
        private Product product;

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Brand> Brands { get; set; }
        //public Product Product { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Quatity")]
        [Required]
        public int Quatity { get; set; }

        [Display(Name = "Number in stock")]
        [Required]
        [Range(1,20)]
        public int NumberInStock { get; set; }

        [Display(Name = "Date of Adding")]
        [Required]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Expiration date")]
        [Required]
        public DateTime? DateToExpire { get; set; }

        [Display(Name = "Number Available")]
        [Required]
        public int? NumberAvailable { get; set; }


        [Display(Name = "Category")]
        [Required]
        public int? CategoryId { get; set; }

        [Display(Name = "Brand")]
        [Required]
        public int? BrandId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
        public ProductFormViewModel()
        {
            Id = 0;
        }

        public ProductFormViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Quatity = product.Quatity;
            NumberInStock = product.NumberInStock;
            DateAdded = product.DateAdded;
            DateToExpire = product.DateToExpire;
            NumberAvailable = product.NumberAvailable;

        }

  
    }
}