using HarryStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using HarryStoreApp.ViewModels;
using HarryStoreApp.Services;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HarryStoreApp.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationUserManager _manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        private ApplicationSignInManager _signInManager;
        private CustomerService service = new CustomerService();
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return _manager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set { _manager = value; }
        }

        //GET
        public ActionResult CreateCustomer()
        {
            var membershipTypes = CustomerService._context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                
            };
            return View("CustomerForm", viewModel);
        }
        public ActionResult Index()
        {
           
            return View("List" );
        }

        [HttpPost]
        public async Task<ActionResult> Save(CustomerFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var membershipTypes = CustomerService._context.MembershipTypes.ToList();
                var viewModel = new CustomerFormViewModel
                {
                    MembershipTypes = membershipTypes
                };
                ModelState.AddModelError("1", "Failed to create customer");
                return View("CustomerForm", viewModel);
            }
            if (model.Id == 0)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Email
                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    service.CreateCustomer(model, user.Id);
                    var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
                    var rolemanager = new RoleManager<IdentityRole>(roleStore);
                    await rolemanager.CreateAsync(new IdentityRole("Customers"));
                    await UserManager.AddToRoleAsync(user.Id, "Customers");
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    //if successfully creates customer
                    TempData["Message"] = "Customer account created successfully";
                    return RedirectToAction("Index", "Customer");
                }
            }
            else
            {
                var customerInDb = CustomerService._context.Customers.Single(m => m.Id == model.Id);
                customerInDb.Name = model.Name;
                customerInDb.Id= model.Id;
                customerInDb.IsSubscribedToNewsLetter= model.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = model.MembershipTypeId;
                customerInDb.BalanceInAccount = model.BalanceInAccount;
            }
            CustomerService._context.SaveChanges();
            return RedirectToAction("Index", "Customer");


        }

        public ActionResult Edit(int id)
        {
            var customer = CustomerService._context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes =CustomerService._context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
       
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var customer = CustomerService._context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            CustomerService._context.Customers.Remove(customer);
            CustomerService._context.SaveChanges();
            return View("Index", "Customer");
        }

    }
}