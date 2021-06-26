using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
     class Appliance :Products
    {   
        public string Model { get; set; }

        public string ProductionDate { get; set; }
        
        public double Weight { get; set; }
    }
}
