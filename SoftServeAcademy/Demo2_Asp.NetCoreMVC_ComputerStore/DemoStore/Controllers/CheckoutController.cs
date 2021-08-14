using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoStore.Data;
using DemoStore.Helpers;
using DemoStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{
    [Route("Checkout")]
    public class CheckoutController : Controller
    {
        private readonly IProductRepository productRepository;
        public CheckoutController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [Route("products")]
        [HttpGet]
        [Authorize(Roles = "user")]
        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);

                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }


        [HttpGet]
        public IActionResult BuyNow()
        {

            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            foreach (var item in cart)
            {
                productRepository.DecreaseQuantity(item.Product, item.Quantity);
            }

            return RedirectToAction("Index", "Product");
        }
    }
}