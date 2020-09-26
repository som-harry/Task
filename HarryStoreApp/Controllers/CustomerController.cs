using HarryStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using HarryStoreApp.ViewModels;

namespace HarryStoreApp.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _Context;
        public CustomerController()
        {
            _Context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }

        [Authorize (Roles = "CanManageCustomers")]
        public ActionResult New()
        {
            var membershipTypes = _Context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.Id == 0)
                    _Context.Customers.Add(customer);
                else
                {
                    var CustomerInDb = _Context.Customers.Single(c => c.Id == customer.Id);
                    CustomerInDb.Name = customer.Name;
                    CustomerInDb.BalanceInAccount = customer.BalanceInAccount;
                    CustomerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                    CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
                }
                _Context.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }

                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _Context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            

            
        }
        
        // GET: Customer
        public ActionResult Index()
        {
            if (User.IsInRole("CanManageCustomers"))
                return View("List");
            
            return View("ReadOnlyList");
        }
        public ActionResult Details(int id)
        {
            var customer = _Context.Customers.SingleOrDefault(c => c.Id == id);
           var MembershipTypes = _Context.MembershipTypes.ToList();

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Edit(int id)
        {
            var customer = _Context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                 MembershipTypes = _Context.MembershipTypes.ToList()
        };
            return View("CustomerForm", viewModel);
        }
    }
}