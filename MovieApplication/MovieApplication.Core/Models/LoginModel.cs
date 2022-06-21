using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieApplication.Core.Models
{
    public class LoginModel
    {
        [Required]
        public string Username{ get; set; }
        [Required]
        public string Password{ get; set; }
    }
}
