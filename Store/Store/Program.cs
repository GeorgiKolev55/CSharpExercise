using System;

namespace Store
{
    class Program
    {
        static void Main(string[] args)
        {

            Food food = new Food() { Name = "apples", Brand = "BrandA", ExpirationDate = DateTime.Parse("28.06.21"), Price = 1.50m };
            
            Beverage milk = new Beverage() { Name = "milk", Brand = "BrandM", Price = 0.99m, ExpirationDate = DateTime.Parse("02.03.22") };

            Clothes shirt = new Clothes() { Name = "T-shirt", Brand = "BransT", Color = "violet", Size = ClothesSize.M, Price = 15.99m };
            
            Appliance laptop = new Appliance() { Name = "laptop", Brand = "BrandL", Price = 2345m, Model = "ModelL", ProductionDate = DateTime.Parse("03-03-20"), Weight = 1.125 };

            Cart cart = new Cart();

            cart.AddProduct(food, 2.45f);
            cart.AddProduct(milk, 3);
            cart.AddProduct(shirt, 2);
            cart.AddProduct(laptop, 1);

            var date = cart.PurchaseDateTime();

            Cashier cashier = new Cashier();

            cashier.PrintReceipt(cart.GetAllProducts, date);
            
        }
    }
}
