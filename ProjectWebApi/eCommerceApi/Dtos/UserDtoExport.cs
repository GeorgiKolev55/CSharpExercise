using eCommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Dtos
{
    public class UserDtoExport
    {
        public int Id { get; set; }
        public string Username { get; set; }
     
        public CurrencyCode CurrencyCode { get; set; }
    }
}
