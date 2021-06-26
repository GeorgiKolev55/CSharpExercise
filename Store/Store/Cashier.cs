using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Cashier
    {
        public void PrintReceipt(IDictionary<string, object[]> products, string dateTime)
        {

            StringBuilder receipt = new StringBuilder();

            decimal totalDiscount = 0;
            decimal totalSum = 0;

            receipt.AppendLine("Date: " + dateTime + "\n");
            receipt.AppendLine("---Products---\n\n");

            foreach (var item in products)
            {
                if (item.Value[0] is Beverage)
                {
                    var bevareage = item.Value[0] as Beverage;
                    receipt.AppendLine(bevareage.Name + " " + bevareage.Brand);

                    decimal beveragesPrice = (decimal)item.Value[1] * bevareage.Price;
                    totalSum += beveragesPrice;

                    receipt.AppendLine($"{item.Value[1]}x ${bevareage.Price:F2} = ${beveragesPrice:F2}");
                    int discount = DiscountForPerishableProducts(bevareage.ExpirationDate);

                    if (discount != 0)
                    {
                        decimal discountInDollars = ((decimal)item.Value[1] * bevareage.Price) / (100 / discount);
                        totalDiscount += discountInDollars;
                        receipt.AppendLine($"#discount {discount}% -${discountInDollars:F2}");
                    }

                    receipt.AppendLine();
                    receipt.AppendLine();
                }

                else if (item.Value[0] is Food)
                {
                    var food = item.Value[0] as Food;
                    receipt.AppendLine(food.Name + "-" + food.Brand + "\n");

                    decimal foodsPrice = (decimal)item.Value[1] * food.Price;
                    totalSum += foodsPrice;

                    receipt.AppendLine($"{item.Value[1]}x ${food.Price:F2} = ${foodsPrice:F2}\n");

                    int discount = DiscountForPerishableProducts(food.ExpirationDate);

                    if (discount != 0)
                    {
                        decimal discountInDollars = ((decimal)item.Value[1] * food.Price) / (100 / discount);
                        totalDiscount += discountInDollars;

                        receipt.AppendLine($"#discount {discount}% -${discountInDollars:F2}\n");
                    }
                    receipt.AppendLine();

                }

                else if (item.Value[0] is Appliance)
                {
                    var appliance = item.Value[0] as Appliance;

                    receipt.AppendLine(appliance.Name + " " + appliance.Brand + " " + appliance.Model);

                    decimal appliancesPrice = (decimal)item.Value[1] * appliance.Price;
                    totalSum += appliancesPrice;

                    receipt.AppendLine($"{item.Value[1]}x ${appliance.Price:F2} = ${appliancesPrice:F2}");
                }

                else if (item.Value[0] is Clothes)
                {
                    var clothes = item.Value[0] as Clothes;

                    receipt.AppendLine(clothes.Name + " " + clothes.Brand + " " + clothes.Color);

                    decimal clothesPrice = (decimal)item.Value[1] * clothes.Price;
                    totalSum += clothesPrice;

                    receipt.AppendLine($"{item.Value[1]}x ${clothes.Price:F2} = ${clothesPrice:F2}");

                    int discount = DiscountForClothes(clothes.Price);

                    if (discount != 0)
                    {

                        decimal discountInDollars = ((decimal)item.Value[1] * clothes.Price) / (100 / discount);
                        totalDiscount += discountInDollars;
                        receipt.AppendLine($"#discount {discount}% -${discountInDollars:F2}");
                    }
                    receipt.AppendLine();
                }
            }

            receipt.AppendLine("-----------------------------------------------------------------------------------\n");

            receipt.AppendLine($"SUBTOTAL: ${totalSum:F2}");
            receipt.AppendLine($"DISCOUNT: -${totalDiscount:F2} \n");
            receipt.AppendLine($"TOTAL: {totalSum - totalDiscount:F2}");

            Console.WriteLine(receipt.ToString());

        }

        private int DiscountForPerishableProducts(string expirationDate)
        {

            int currentDay = DateTime.Now.Day;
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            var productDate = DateTime.Parse(expirationDate);
            int productDay = productDate.Day;
            int productMonth = productDate.Month;
            int productYear = productDate.Year;

            if (productYear == currentYear && productMonth == currentMonth && productDay == currentDay)
            {
                return 50;
            }

            else if (productYear == currentYear && productMonth == currentMonth && productDay < currentDay + 5)
            {
                return 10;
            }
            return 0;
        }

        private int DiscountForClothes(decimal clothePrice)
        {

            string dayOfTheWeek = DateTime.Now.DayOfWeek.ToString();
            if (dayOfTheWeek == "Monday" || dayOfTheWeek == "Tuesday" || dayOfTheWeek == "Wednesday" || dayOfTheWeek == "Thursday" || dayOfTheWeek == "Friday")
            {
                return 10;
            }
            else if ((dayOfTheWeek == "Saturday" || dayOfTheWeek == "Sunday") && clothePrice > 999)
            {
                return 5;
            }
            return 0;
        }
    }
}
