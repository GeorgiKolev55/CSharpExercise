using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Appliance : Products, IDiscount
    {
        private const int FIVE_PERCENT_DISCOUNT = 5;

        public string Model { get; set; }

        public DateTime ProductionDate { get; set; }

        public double Weight { get; set; }

        public override string ToReceipt(decimal amount)
        {
            string toReturn = base.ToString() + $" {Model}\n{amount} x ${this.Price} = ${amount * this.Price:F2}\n";
           
            if (CheckForDiscount() != 0)
            {
                int discount = CheckForDiscount();

                var discountInDollars = amount * this.Price / (100 / discount);
                base.discountOfProduct = discountInDollars;
                toReturn += $"#discount {discount}% -${discountInDollars:F2}\n";
            }

            return toReturn;
        }

        public int CheckForDiscount()
        {

            string dayOfTheWeek = DateTime.Now.DayOfWeek.ToString();

            int priceForDiscount = 999;

            if ((dayOfTheWeek == "Saturday" || dayOfTheWeek == "Sunday") && this.Price > priceForDiscount)
            {
                return FIVE_PERCENT_DISCOUNT;
            }

            return 0;
        }
    }
}
