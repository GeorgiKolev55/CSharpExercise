using AutoMapper;
using eCommerceApi.Dtos;
using eCommerceApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Data
{
    public static class Deserializer
    {
        public static void ImportAllProducts(ECommerceContext context)
        {

            var d = Directory.GetCurrentDirectory();
            var pathFile = Path.GetFileName(d);
            var text = File.ReadAllText(@"C:\Users\gK\source\repos\eCommerceApi\eCommerceApi\Data\products.json");
            var productsDto = JsonConvert.DeserializeObject<Product[]>(text);
            List<Product> products = new List<Product>();
            foreach (var item in productsDto)
            {
               
                products.Add(item);
            }
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
