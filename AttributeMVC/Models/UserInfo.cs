using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttributeMVC.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [EmailValidation(allowedDomain: "thinkbridge.in", ErrorMessage = "The input mail id must be 'thinkbridge.in")]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
