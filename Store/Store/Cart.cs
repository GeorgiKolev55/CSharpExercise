using System;
using System.Collections.Generic;

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


        public void AddProduct(Products product, decimal amount)
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
