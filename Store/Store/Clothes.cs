using System;

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
        private const int TEN_PERCENT_DISCOUNT = 10;
        
        public ClothesSize Size { get; set; }

        public string Color { get; set; }

        public override string ToReceipt(float amount)
        {
            string toReturn = base.ToString() + $" {Color}\n{amount} x ${this.Price} = ${(decimal)amount * this.Price:F2}\n";
           
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

            var dayOfTheWeek = DateTime.Today.DayOfWeek.ToString();

            if (dayOfTheWeek != "Saturday" && dayOfTheWeek != "Sunday")
            {
                return TEN_PERCENT_DISCOUNT;
            }

            return 0;
        }
    }
}
