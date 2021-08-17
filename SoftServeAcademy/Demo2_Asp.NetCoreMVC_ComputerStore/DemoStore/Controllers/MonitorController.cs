using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoStore.Data;
using DemoStore.Models.Enum;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{
    [Route("monitor")]
    public class MonitorController : Controller
    {

        private readonly IProductRepository productRepository;
        public MonitorController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [Route("")]
        public IActionResult Index()
        {
            var monitorProducts = productRepository.GetAll(ProductType.monitor); 

            return View(monitorProducts);
        }
    }
}