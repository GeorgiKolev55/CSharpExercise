using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Models
{
    public class CurrencyCode
    {
        [Key]
        public int Id { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
        public string Rates { get; set; }
    }
}
