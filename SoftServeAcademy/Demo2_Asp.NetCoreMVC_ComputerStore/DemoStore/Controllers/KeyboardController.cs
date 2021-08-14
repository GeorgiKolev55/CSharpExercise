using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{
    [Route("keyboard")]
    public class KeyboardController : Controller
    {
        private readonly IProductRepository productRepository;
        public KeyboardController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            var productType = "keyboard";

            var products = productRepository.GetAll(productType);

            return View(products);
        }
    }
}