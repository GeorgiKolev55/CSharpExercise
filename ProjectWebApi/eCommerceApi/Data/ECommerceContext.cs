using eCommerceApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext()
        {

        }
        public ECommerceContext(DbContextOptions<ECommerceContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
