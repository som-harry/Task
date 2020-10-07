using HarryStoreApp.Models;
using HarryStoreApp.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Web.HttpContext;



namespace HarryStoreApp.Controllers
{
    [Authorize(Roles ="Customers")]
    public class ShopNowController : Controller
    {
       
        private CartServices service = new CartServices();


        // GET: ShopNow
        public ActionResult Index()
        {
            var userId = Current.User.Identity.GetUserId();
            var product = CartServices.GetAllProducts();
            service.OpenCart(userId);
            return View(product);

        }

        public ActionResult OpenCart()
        {
            var userId = Current.User.Identity.GetUserId();
            var cart = service.OpenCart(userId);
            return View(cart);
        }


        public ActionResult AddTOCart(int productId)
        {
           var userId = Current.User.Identity.GetUserId();
            service.AddTOCart(userId, productId);
            return View("Index", CartServices.GetAllProducts());
        }

    }
}