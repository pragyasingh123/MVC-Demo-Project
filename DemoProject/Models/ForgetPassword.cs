using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoProject.Models
{
    public class ForgetPassword
    {

        [DisplayName("Please enter Email ID")]
        [Required(ErrorMessage = "Please enter email ID ", AllowEmptyStrings = false)]
        public string UserEmailID { get; set; }

        [DisplayName("Please enter new password")]
        [Required(ErrorMessage = "Please enter password ", AllowEmptyStrings = false)]
        public string UserPassword { get; set; }

      
    }
}