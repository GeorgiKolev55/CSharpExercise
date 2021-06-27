using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Products
    {

        internal decimal discountOfProduct;

        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        
        public virtual string ToReceipt(decimal amount)
        {
            return "";
        }
        public override string ToString()
        {
            return $"{Name} {Brand}"; ;
        }
    }
}
