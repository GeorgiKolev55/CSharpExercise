using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    enum ClothesSize { 
        XS ,
        S,
        M,
        L,
        XL

    }
    class Clothes : Products
    {         
        public ClothesSize Size { get ;  set ;  }
       
        public string Color { get; set; }       
    }
}
