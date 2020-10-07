using HarryStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using HarryStoreApp.ViewModels;
using HarryStoreApp.Services;

namespace HarryStoreApp.Controllers
{
    public class ProductController : Controller
    {
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductFormViewModel(product)
                {
                    Categories = ProductService._context.Categories.ToList(),
                    Brands = ProductService._context.Brands.ToList()
                };
                return View("ProductForm", viewModel);
            }

            if (product.Id == 0)
            {
                product.DateAdded = DateTime.Now;
                ProductService._context.Products.Add(product);
            }
            else
            {
                var productInDb = ProductService._context.Products.Single(m => m.Id == product.Id);

                productInDb.Id = product.Id;
                productInDb.Name = product.Name;
                productInDb.Quatity = product.Quatity;
                productInDb.NumberInStock = product.NumberInStock;
                productInDb.DateAdded = product.DateAdded;
                productInDb.DateToExpire = product.DateToExpire;
                productInDb.NumberAvailable = product.NumberAvailable;

            }

            ProductService._context.SaveChanges();
            return RedirectToAction("Index","Product");
        }

        // GET: Product
        public ViewResult Index()
        {
            var product = ProductService._context.Products.Include(c => c.Category).ToList();
            var Brands = ProductService._context.Brands.ToList();

            if (User.IsInRole("CanManageCustomers"))
                return View("List", product);

            return View("ReadOnlyList",product);
        }


        [Authorize (Roles = "CanManageCustomers")]
        public ViewResult New()
        {
            var Brands = ProductService._context.Brands.ToList();
            var Categories = ProductService._context.Categories.ToList();

            var viewModel = new ProductFormViewModel
            {
                Brands = Brands,
                Categories = Categories
            };

            return View("ProductForm", viewModel);
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Edit(int id)
        {
            var product = ProductService._context.Products.SingleOrDefault(c => c.Id == id);
            if (product.Id == 0)
                return HttpNotFound();

            var viewModel = new ProductFormViewModel(product)
            {
                Categories = ProductService._context.Categories.ToList(),
                Brands = ProductService._context.Brands.ToList()
            };
            return View("ProductForm",viewModel);
        }


        public ActionResult Details(int id)
        {
            var product = ProductService._context.Products.SingleOrDefault(p => p.Id == id);
            var categories = ProductService._context.Categories.ToList();
            var Brands = ProductService._context.Brands.ToList();
            

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

    }
}