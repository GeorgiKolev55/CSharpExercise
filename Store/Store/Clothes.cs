using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    enum ClothesSize
    {
        XS,
        S,
        M,
        L,
        XL

    }
    class Clothes : Products, IDiscount
    {
        public ClothesSize Size { get; set; }

        public string Color { get; set; }

        public override string ToReceipt(float amount)
        {
            string toReturn = base.ToReceipt(amount) + $" {Color}\n{amount} x ${this.Price} = ${(decimal)amount * this.Price:F2}\n";
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
            if (dayOfTheWeek == "Monday" || dayOfTheWeek == "Tuesday" || dayOfTheWeek == "Wednesday" || dayOfTheWeek == "Thursday" || dayOfTheWeek == "Friday")
            {
                return 10;
            }

            return 0;
        }
    }
}
