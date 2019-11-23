using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        [Required(ErrorMessage ="Please enter your first name")]
        [Display(Name ="First Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage ="First name must be between 2 and 20 letters")]
        public String firstname { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 20 letters")]
        public String lastname { get; set; }

        [Required(ErrorMessage = "Please enter your address name")]
        [Display(Name = "Address")]
        [StringLength(40,ErrorMessage = "Address is a maximum of 40 characters")]
        public String address { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [Display(Name = "City")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "City must be between 2 and 20 letters")]
        public String city { get; set; }


        [Required(ErrorMessage = "Please enter your state")]
        [Display(Name = "State")]
        public String state { get; set; }

        [Required(ErrorMessage = "Please enter your zip")]
        [Display(Name = "Zip Code")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Zip is 5 digits")]
        public String zip { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage ="Not a valid email")]
        [Display(Name = "Email")]
        public String email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\+?\(?\d+\)?(\s|\-|\.)?\d{1,3}(\s|\-|\.)?\d{4}[\s]*[\d]*$", ErrorMessage ="Phone numbers must be put into proper format (xxx)-XXX-XXXX")]
        public String phone { get; set; }
    }
}