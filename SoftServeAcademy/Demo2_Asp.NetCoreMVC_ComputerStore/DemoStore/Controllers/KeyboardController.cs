using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoStore.Data;
using DemoStore.Models.Enum;
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
            var products = productRepository.GetAll(ProductType.keyboard);

            return View(products);
        }
    }
}