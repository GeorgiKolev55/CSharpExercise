using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Program
    {
        static void Main(string[] args)
        {

            Food food = new Food() { Name = "apples", Brand = "BrandA", ExpirationDate = "28.06.21", Price = 1.50m };

            Beverage milk = new Beverage() { Name = "milk", Brand = "BrandM", Price = 0.99m, ExpirationDate = "02.03.22" };


            Clothes shirt = new Clothes() { Name = "T-shirt", Brand = "BransT", Color = "violet", Size = ClothesSize.M, Price = 15.99m };
            Appliance laptop = new Appliance() { Name = "laptop", Brand = "BrandL", Price = 2345m, Model = "ModelL", ProductionDate = "03.03.21", Weight = 1.125 };

            Cart cart = new Cart();

            cart.AddProduct(food, 2.45m);
            cart.AddProduct(milk, 3m);
            cart.AddProduct(shirt, 2m);
            cart.AddProduct(laptop, 1m);

            var date = cart.PurchaseDateTime();
            Cashier cashier = new Cashier();
            cashier.PrintReceipt(cart.GetAllProducts, date);
        }
    }
}
