using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Cart
    {
        private readonly List<ProductAndAmount> products;

        public Cart()
        {
            products = new List<ProductAndAmount>();
        }

        public List<ProductAndAmount> GetAllProducts => this.products;


        public void AddProduct(Products product, float amount)
        {
            ProductAndAmount productAndAmount = new ProductAndAmount() { Product = product, Amount = amount };
            products.Add(productAndAmount);
        }

        public DateTime PurchaseDateTime()
        {
            return DateTime.Now;

        }
    }
}
