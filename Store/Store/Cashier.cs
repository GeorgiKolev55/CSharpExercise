using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Cashier
    {
        public void PrintReceipt(List<ProductAndAmount> products, DateTime dateTime)
        {

            StringBuilder receipt = new StringBuilder();

            decimal totalDiscount = 0;
            decimal totalSum = 0;

            receipt.AppendLine("Date: " + dateTime + "\n");
            receipt.AppendLine("---Products---\n\n");

            foreach (var item in products)
            {
                var amount = item.Amount;
                var product = item.Product;

                decimal price = amount * product.Price;
                totalSum += price;

                receipt.Append(product.ToReceipt(amount));

                totalDiscount += product.discountOfProduct;
                receipt.AppendLine();
            }

            receipt.AppendLine("-----------------------------------------------------------------------------------\n");

            receipt.AppendLine($"SUBTOTAL: ${totalSum:F2}");
            receipt.AppendLine($"DISCOUNT: -${totalDiscount:F2} \n");
            receipt.AppendLine($"TOTAL: {totalSum - totalDiscount:F2}");

            Console.WriteLine(receipt.ToString());

        }
    }

}
