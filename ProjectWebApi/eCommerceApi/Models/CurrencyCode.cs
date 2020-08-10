using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Models
{
    public class CurrencyCode
    {
        public int Id { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
        public string Rates { get; set; }
    }
}
