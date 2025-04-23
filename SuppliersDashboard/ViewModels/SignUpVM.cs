using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class SignUpVM
    {
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-1]{2})\)?[-. ]?([0-9]{5})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage ="UserName is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password Required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}