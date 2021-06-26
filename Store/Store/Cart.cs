using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Cart
    {
        private readonly IDictionary<string, object[]> products;

        public Cart()
        {
            products = new Dictionary<string, object[]>();
        }

        public IDictionary<string, object[]> GetAllProducts => this.products;


        public void AddProduct(Products product, decimal WeightOrQuantity)
        {
            if (product is Appliance)
            {
                var appliance = product as Appliance;
                string key = appliance.Name + appliance.Brand + appliance.Model;

                if (!this.products.ContainsKey(key))
                {

                    products.Add(key, new object[2]);
                    products[key][0] = product;
                    products[key][1] = WeightOrQuantity;

                }
                else
                {
                    var price = product.Price;
                    var ll = products[key][1];
                    var rr = price + (decimal)ll;
                    products[key][1] = rr;
                }
            }
            else if (product is Clothes)
            {
                var appliance = product as Clothes;

                string key = appliance.Name + appliance.Brand + appliance.Color;

                if (!this.products.ContainsKey(key))
                {

                    products.Add(key, new object[2]);
                    products[key][0] = product;
                    products[key][1] = WeightOrQuantity;

                }
                else
                {
                    var price = product.Price;
                    var ll = products[key][1];
                    var rr = price + (decimal)ll;
                    products[key][1] = rr;
                }
            }
            else
            {
                string key = product.Name + product.Brand;

                if (!this.products.ContainsKey(key))
                {

                    products.Add(key, new object[2]);
                    products[key][0] = product;
                    products[key][1] = WeightOrQuantity;

                }
                else
                {
                    var price = product.Price;
                    var ll = products[key][1];
                    var rr = price + (decimal)ll;
                    products[key][1] = rr;
                }
            }

        }

        public string PurchaseDateTime()
        {
            return DateTime.Now.ToString();

        }
    }
}
