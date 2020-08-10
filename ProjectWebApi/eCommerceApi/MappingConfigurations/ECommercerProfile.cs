using AutoMapper;
using eCommerceApi.Dtos;
using eCommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.MappingConfigurations
{
    public class ECommercerProfile :Profile
    {
        public ECommercerProfile()
        {
            CreateMap<UserDtoImport, User>();
            CreateMap<ProductDtoImport, Product>();
            CreateMap<OrderDtoImport, Order>();
            CreateMap<User, UserDtoExport>();
            CreateMap<Product, ProductDtoExport>();
            CreateMap<Order, OrderDtoExport>();
            
        }
    }
}
