using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Models
{
    
    public class LoginModel
    {
        public LoginModel() { }

        [Required]
        [Key]
        public long aadharno { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
