using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoStore.Data;

using Microsoft.AspNetCore.Mvc;



namespace DemoStore.Controllers
{
  
    [Route("mouse")]
    public class MouseController : Controller
    {
        private readonly IProductRepository productRepository;
        public MouseController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            var productType = "mouse";

            var mouseProducts= productRepository.GetAll(productType);

            return View(mouseProducts);
        }
    }
}