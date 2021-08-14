using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoStore.Data;
using DemoStore.Helpers;
using DemoStore.Models;

using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {

        private readonly IProductRepository productRepository;
        public CartController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [Route("products")]
        [HttpGet]
        public IActionResult Index()
        {

            try
            {
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;


                ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);

                return View();
            }
            catch (ArgumentNullException)
            {

                return Redirect("/");
            }

        }
        private int IsExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }

            }
            
            return -1;
        }

       
       [HttpGet] 
        public IActionResult Buy(int id)
        {
           
            string productType = productRepository.FindById(id).Type;
            var product = productRepository.FindById(id);

            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                if (product.Quantity<=0)
                {
                    return RedirectPermanent("~/Product/ProductAmount");
                }
                List<Item> cart = new List<Item>();
             
                cart.Add(new Item { Product = product, Quantity = 1 });
                
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {

                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

                int index = IsExist(id);

                if (index != -1)
                {
                    ViewBag.currentQuantity = cart[index].Quantity;
                    if ( cart[index].Quantity < product.Quantity)
                    {
                        cart[index].Quantity++;
                    }
                    else { return RedirectToAction("ProductAmount","Product"); }
                }
                else
                {
                    cart.Add(new Item { Product = this.productRepository.FindById(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return Redirect(productType);

        }


        [Route("remove")]      
        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            try
            {
                int index = IsExist(id);
                cart.RemoveAt(index);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return RedirectToAction("Index");
            }
            catch (NullReferenceException)
            {
                return Redirect("/");
            }



        }
    }
}