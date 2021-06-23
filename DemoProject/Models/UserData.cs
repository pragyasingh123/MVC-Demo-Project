using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DemoProject.Models
{
    public class UserData
    {
       [DisplayName("User Name")]
        [Required(ErrorMessage = "Please enter user name", AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [DisplayName("User Pasword")]

        [Required(ErrorMessage = "Please enter password ", AllowEmptyStrings = false)]
        public string UserPassword { get; set; }
    }
}