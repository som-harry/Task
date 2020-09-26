using HarryStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using HarryStoreApp.ViewModels;

namespace HarryStoreApp.Controllers
{
    public class ProductController : Controller
    {
        
        private ApplicationDbContext _Context;
        public ProductController()
        {
            _Context = new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductFormViewModel(product)
                {
                    Categories = _Context.Categories.ToList(),
                    Brands = _Context.Brands.ToList()
                };
                return View("ProductForm", viewModel);
            }

            if (product.Id == 0)
            {
                product.DateAdded = DateTime.Now;
                _Context.Products.Add(product);
            }
            else
            {
                var productInDb = _Context.Products.Single(m => m.Id == product.Id);

                productInDb.Id = product.Id;
                productInDb.Name = product.Name;
                productInDb.Quatity = product.Quatity;
                productInDb.NumberInStock = product.NumberInStock;
                productInDb.DateAdded = product.DateAdded;
                productInDb.DateToExpire = product.DateToExpire;
                productInDb.NumberAvailable = product.NumberAvailable;

            }

            _Context.SaveChanges();
            return RedirectToAction("Index","Product");
        }

        // GET: Product
        public ViewResult Index()
        {
            var product = _Context.Products.Include(c => c.Category).ToList();
            var Brands = _Context.Brands.ToList();

            if (User.IsInRole("CanManageCustomers"))
                return View("List", product);

            return View("ReadOnlyList",product);
        }


        [Authorize (Roles = "CanManageCustomers")]
        public ViewResult New()
        {
            var Brands = _Context.Brands.ToList();
            var Categories = _Context.Categories.ToList();

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
            var product = _Context.Products.SingleOrDefault(c => c.Id == id);
            if (product.Id == 0)
                return HttpNotFound();

            var viewModel = new ProductFormViewModel(product)
            {
                //Id = product.Id,
                //Name = product.Name,
                //DateAdded = product.DateAdded,
                //NumberInStock = product.NumberInStock,
                //Quatity = product.Quatity,
                //NumberAvailable = product.NumberAvailable,
                //DateToExpire = product.DateToExpire,
                Categories = _Context.Categories.ToList(),
                Brands = _Context.Brands.ToList()
            };
            return View("ProductForm",viewModel);
        }


        public ActionResult Details(int id)
        {
            var product = _Context.Products.SingleOrDefault(p => p.Id == id);
            var categories = _Context.Categories.ToList();
            var Brands = _Context.Brands.ToList();
            

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}