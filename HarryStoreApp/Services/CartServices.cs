using HarryStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HarryStoreApp.Services
{
    public class CartServices
    {
        public static ApplicationDbContext _context = new ApplicationDbContext();
        public static List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Cart OpenCart(string userId)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.UserId == userId);
            if (customer == null)
                throw new Exception("Customer not found");

            var cart = _context.Carts.Include("OrderItems").ToList().SingleOrDefault(c => c.CustomerId == customer.Id);
            if (cart == null)
                cart = new Cart()
                {
                    Customer = customer,
                    OrderItems = new List<OrderItem>()
                };
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return cart;
        }

        public  Cart GetUserCart(string userId)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.UserId == userId);
            if (customer == null)
                throw new Exception("Customer not found");
            return _context.Carts.SingleOrDefault(c => c.CustomerId == customer.Id);

        }

        public  void AddTOCart(string userid, int productId)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == productId);
            var userCart = GetUserCart(userid);
            if (product == null)
                throw new Exception("Product Not Found");
            var orderProduct = userCart.OrderItems.SingleOrDefault(c => c.productId == product.Id);
            if(orderProduct == null)
            {
                var orderitem = new OrderItem()
                {
                    Product = product,
                    Quantity = 1,
                    Cart = userCart
                };
                _context.OrderItems.Add(orderitem);
                _context.SaveChanges();
            }
            else
            {
                orderProduct.Quantity++;
                _context.Entry(orderProduct).State = EntityState.Modified;
            }
            _context.Entry(userCart).State = EntityState.Modified;
            _context.SaveChanges();

        }

    }
}