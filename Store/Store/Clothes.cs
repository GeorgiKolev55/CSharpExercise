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
        private const int TenPercentDiscount = 10;
        
        public ClothesSize Size { get; set; }

        public string Color { get; set; }

        public override string ToReceipt(decimal amount)
        {
            string toReturn = base.ToString() + $" {Color}\n{amount} x ${this.Price} = ${amount * this.Price:F2}\n";
           
            if (CheckForDiscount() != 0)
            {
                int discount = CheckForDiscount();

                var discountInDollars = (amount * this.Price) / (100 / discount);
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
                return TenPercentDiscount;
            }

            return 0;
        }
    }
}
