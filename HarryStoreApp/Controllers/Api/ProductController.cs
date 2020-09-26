using AutoMapper;
using HarryStoreApp.Dtos;
using HarryStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HarryStoreApp.Controllers.Api
{
    public class ProductController : ApiController
    {
        private ApplicationDbContext _Context;
        public ProductController()
        {
            _Context = new ApplicationDbContext();
        }

        //Get /api/product
        public IEnumerable<ProductDtos> GetProducts()
        {
            return _Context.Products.ToList().Select(Mapper.Map<Product, ProductDtos>);
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = _Context.Products.SingleOrDefault(c => c.Id == id);

            if (product == null)
                return NotFound();

            return Ok(Mapper.Map<Product, ProductDtos>(product));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(ProductDtos productDtos)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = Mapper.Map<ProductDtos, Product>(productDtos);
            _Context.Products.Add(product);
            _Context.SaveChanges();

            productDtos.Id = product.Id;
            return Created(new Uri(Request.RequestUri + "/" + product.Id), productDtos);
        }

        [HttpPut]
     
        public IHttpActionResult UpdateMovie(int id, ProductDtos productDtos)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productInDb = _Context.Products.SingleOrDefault(c => c.Id == id);

            if (productInDb == null)
                return NotFound();

            Mapper.Map(productDtos,productInDb);

            _Context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var productInDb = _Context.Products.SingleOrDefault(c => c.Id == id);

            if (productInDb == null)
                return NotFound();

            _Context.Products.Remove(productInDb);
            _Context.SaveChanges();

            return Ok();
        }

    }
}
