﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Beverage : Products, IDiscount
    {
        private const int FiftyPercentDiscount = 50;
        private const int TenPercentDiscount = 10;

        public DateTime ExpirationDate { get; set; }

        public override string ToReceipt(decimal amount)
        {
            string toReturn = base.ToString() + $"\n{amount} x {this.Price} = {amount * this.Price:F2}\n";

            if (CheckForDiscount() != 0)
            {
                int discount = CheckForDiscount();

                var discountInDollars = amount * this.Price / (100 / discount);
                base.discountOfProduct = discountInDollars;

                toReturn += $"#discount {discount}% {discountInDollars:F2}\n";
            }
            return toReturn;
        }

        public int CheckForDiscount()
        {

            if (this.ExpirationDate.Equals(DateTime.Now))
            {
                return FiftyPercentDiscount;
            }

            else if (this.ExpirationDate < DateTime.Now.AddDays(5))
            {
                return TenPercentDiscount;
            }
            return 0;
        }
    }
}
