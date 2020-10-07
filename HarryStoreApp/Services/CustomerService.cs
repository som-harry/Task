using HarryStoreApp.Models;
using HarryStoreApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarryStoreApp.Services
{
    public class CustomerService
    {
        public static ApplicationDbContext _context= new ApplicationDbContext();

        public void CreateCustomer(CustomerFormViewModel model, string userid)
        {
            Customer newcustomer = new Customer()
            {
                Name = model.Name,
                IsSubscribedToNewsLetter = model.IsSubscribedToNewsLetter,
                BalanceInAccount = model.BalanceInAccount,
                MembershipTypeId = model.MembershipTypeId,
                UserId = userid

            };
            _context.Customers.Add(newcustomer);
            _context.SaveChanges();
        }
 }  }