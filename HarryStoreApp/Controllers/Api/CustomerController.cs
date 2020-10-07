using AutoMapper;
using HarryStoreApp.Dtos;
using HarryStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;

namespace HarryStoreApp.Controllers.Api
{
    //Get /api/customers 
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _Context;
        public CustomerController()
        {
            _Context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
            base.Dispose(disposing);
        }
        //public IEnumerable<CustomerDtos> GetCustomers()
        //{
        //    return _Context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDtos>);
        //}
        //GET /api/customer
        public IHttpActionResult GetCustomers()
        {
            var customerDto = _Context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDtos>);

            return Ok(customerDto);
        }

        //Get /api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _Context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok (Mapper.Map<Customer, CustomerDtos>( customer));
        }

        //Post api/customer/ 
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDtos customerDtos)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDtos, Customer>(customerDtos);
                 _Context.Customers.Add(customer);
                _Context.SaveChanges();

            customerDtos.Id = customer.Id;
                return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDtos);
            
        }
        //Put api/customer/ 
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDtos customerDtos)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _Context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDtos, customerInDb);
            //customerInDb.BalanceInAccount = customerDtos.BalanceInAccount;
            //customerInDb.Name = customerDtos.Name;
            //customerInDb.IsSubscribedToNewsLetter = customerDtos.IsSubscribedToNewsLetter;
            //customerInDb.MembershipTypeId = customerDtos.MembershipTypeId;

            _Context.SaveChanges();

            return Ok();
        }

        //Delete api/customer/ 
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _Context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();


            _Context.Entry(customerInDb).State = System.Data.Entity.EntityState.Deleted;
            _Context.SaveChanges();

            return Ok();


        }

    }
}
