using DemoStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoStore.Data
{
    public class DemoStoreContext : DbContext
    {
        public DemoStoreContext()
        {

        }
        public DemoStoreContext(DbContextOptions<DemoStoreContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Product> Products { get; set; }
    }
}
