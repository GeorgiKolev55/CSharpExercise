using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Beverage : Products, IDiscount
    {
        public DateTime ExpirationDate { get; set; }

        public override string ToReceipt(float amount)
        {
            string toReturn = base.ToReceipt(amount) + $"\n{amount} x {this.Price} = {(decimal)amount * this.Price:F2}\n";

            if (CheckForDiscount() != 0)
            {
                int discount = CheckForDiscount();

                var discountInDollars = ((decimal)amount * this.Price) / (100 / discount);
                base.discountOfProduct = discountInDollars;

                toReturn += $"#discount {discount}% {discountInDollars:F2}\n";
            }
            return toReturn;
        }

        public int CheckForDiscount()
        {

            int currentDay = DateTime.Now.Day;
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            int productDay = ExpirationDate.Day;
            int productMonth = ExpirationDate.Month;
            int productYear = ExpirationDate.Year;

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
    }
}
