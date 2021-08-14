using AutoMapper;
using DemoStore.Dtos;
using DemoStore.Models;

namespace DemoStore.MappingConfiguration
{
    public class DemoStoreProfile :Profile
    {
        public DemoStoreProfile()
        {
            CreateMap<UserDtoImport, User>();

            CreateMap<ProductDtoImport, Product>();     
            
        }
    }
}
