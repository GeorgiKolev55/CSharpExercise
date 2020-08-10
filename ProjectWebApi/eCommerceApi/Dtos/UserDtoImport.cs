using eCommerceApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Dtos
{
    public class UserDtoImport
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
       
        public CurrencyCode CurrencyCode { get; set; }
    }
}
