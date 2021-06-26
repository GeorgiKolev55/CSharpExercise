using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Appliance : Products, IDiscount
    {
        public string Model { get; set; }

        public DateTime ProductionDate { get; set; }

        public double Weight { get; set; }

        public override string ToReceipt(float amount)
        {
            string toReturn = base.ToReceipt(amount) + $" {Model}\n{amount} x ${this.Price} = ${(decimal)amount * this.Price:F2}\n";
           
            if (CheckForDiscount() != 0)
            {
                int discount = CheckForDiscount();

                var discountInDollars = ((decimal)amount * this.Price) / (100 / discount);
                base.discountOfProduct = discountInDollars;
                toReturn += $"#discount {discount}% -${discountInDollars:F2}\n";
            }

            return toReturn;
        }

        public int CheckForDiscount()
        {

            string dayOfTheWeek = DateTime.Now.DayOfWeek.ToString();

            if ((dayOfTheWeek == "Saturday" || dayOfTheWeek == "Sunday") && this.Price > 999)
            {
                return 5;
            }

            return 0;
        }
    }
}
