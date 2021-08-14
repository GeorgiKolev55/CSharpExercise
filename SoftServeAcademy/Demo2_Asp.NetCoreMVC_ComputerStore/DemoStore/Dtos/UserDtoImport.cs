using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoStore.Dtos
{
    public class UserDtoImport
    {
        
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6,ErrorMessage ="Must be atleast 6 symbols")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public string Role { get; set; }
    }
}
