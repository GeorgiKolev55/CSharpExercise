using DemoStore.Data;
using DemoStore.Models;
using DemoStore.Models.Enum;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace NUnitTestProject
{
    public class ProductRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DemoStoreContext>()
            .UseInMemoryDatabase(databaseName: "ProductListDatabase")
            .Options;

            using (var context = new DemoStoreContext(options))
            {

                context.Products.Add(new Product { Id = 1, Name = "product 1", Price = 12, Type = "mouse", Quantity = 2 });
                context.Products.Add(new Product { Id = 3, Name = "product 3", Price = 12, Type = "laptop", Quantity = 2 });
                context.Products.Add(new Product { Id = 2, Name = "product 2", Price = 12, Type = "monitor", Quantity = 2 });
                context.Products.Add(new Product { Id = 4, Name = "product 4", Price = 12, Type = "mouse", Quantity = 2 });

                context.SaveChanges();
            }

            this.Oprions = options;
        }
        private DbContextOptions<DemoStoreContext> Oprions { get; set; }

        [Test]
        public void GetAllProducts_OfTypeMouse_ReturnsSameType()
        {
            var mockStoreContext = new DemoStoreContext(this.Oprions);

            IProductRepository productRepository = new ProductRepository(mockStoreContext);

            var mouseProducts = productRepository.GetAll(ProductType.mouse);
         
            var actual = mouseProducts.FirstOrDefault(x => x.Type != ProductType.mouse.ToString());

            Assert.IsNull(actual);
        }

        [Test]
        public void FindById_IdNumber_ReturnsSameIdNumber()
        {
            var mockStoreContext = new DemoStoreContext(this.Oprions);

            IProductRepository productRepository = new ProductRepository(mockStoreContext);

            var productWithId2 = productRepository.FindById(2);
            int expectedId = 2;

            Assert.AreEqual(expectedId, productWithId2.Id);
        }

        [Test]
        public void Count_ProductsOfTheCollection_ReturnSameNumber()
        {
            var mockStoreContext = new DemoStoreContext(this.Oprions);

            IProductRepository productRepository = new ProductRepository(mockStoreContext);

            int expectedNumber = 4;

            Assert.AreEqual(expectedNumber, productRepository.Count());
        }

        [Test]
        public void DecreaseQuantity_OfProductByOne_ReturnSameNumber()
        {
            var mockStoreContext = new DemoStoreContext(this.Oprions);

            IProductRepository productRepository = new ProductRepository(mockStoreContext);

            var product = productRepository.FindById(1);

            int expectedQuantity = product.Quantity - 1;

            productRepository.DecreaseQuantity(product, 1);

            Assert.AreEqual(expectedQuantity, productRepository.FindById(1).Quantity);
        }

    }
}