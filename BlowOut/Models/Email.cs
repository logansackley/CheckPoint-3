using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    public class Email
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name="Full Name")]
        public String Name { get; set; }

        [EmailAddress]
        [Display(Name="Email Address")]
        public string Smail { get; set; }

        [EmailAddress]
        [Compare("Smail")]
        [Display(Name= "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        public string ContactInfo { get; set; }

    }
}