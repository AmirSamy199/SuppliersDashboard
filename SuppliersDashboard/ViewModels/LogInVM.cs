using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class LogInVM
    {
     
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string password { get; set; }

    }
}