using AutoMapper;
using eCommerceApi.Data;
using eCommerceApi.Dtos;
using eCommerceApi.Models;
using eCommerceApi.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository repository;
        private readonly IMapper mapper;
        public OrderController(IOrderRepository repository,IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        [HttpPost("create")]
        public IActionResult Create(OrderDtoImport order)
        {
            Order order1 = mapper.Map<Order>(order);
            this.repository.CreateOrder(order1);
            return Ok();
        }
        [HttpPut("change/{id}")]
        public IActionResult ChangeOrder(OrderStatus status, int id)
        {
            this.repository.ChangeOrderStatus(status, id);
            return Ok();
        }
        [HttpGet("users/{id}")]
        public ActionResult <ICollection<OrderDtoExport>> GetUserOrders(int id)
        {
           ICollection<Order> orders= this.repository.GetUserOrders(id);
            return Ok(mapper.Map<ICollection<OrderDtoExport>>(orders));
        }

    }
}
