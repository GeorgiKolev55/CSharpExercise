using AutoMapper;
using eCommerceApi.Data;
using eCommerceApi.Dtos;
using eCommerceApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;
        public ProductController(IProductRepository repository,IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        [HttpPost("create")]
        public IActionResult Create(ProductDtoImport product)
        {
            Product product1 = mapper.Map<Product>(product);
            repository.CreateProduct(product1);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult deleteProduct(int id)
        {
            repository.DeleteProduct(id);
            return Ok();//responseStatus
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDtoExport> GetNewProduct(int id)
        {
            Product product = repository.GetProduct(id);
            if (product==null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ProductDtoExport>(product));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDtoExport>> GetAllProducts()
        {
            var products = repository.GetAllProdcts();
            return Ok(mapper.Map<IEnumerable<ProductDtoExport>>(products));
        }
    }
}
