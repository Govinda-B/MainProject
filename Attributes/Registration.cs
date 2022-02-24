using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    public class Registration
    {
        public Registration()
        {

        }
        [Required]
        [EmailAddress]
        [EmailValidation(allowedDomain:"thinkbridge.in", ErrorMessage ="The input mail id must be 'thinkbridge.in")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
