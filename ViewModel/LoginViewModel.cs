using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter the user name.")]
        [StringLength(50, ErrorMessage = "The user name must be less than {1} characters.")]

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required ]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [ScaffoldColumn(false)]
        public string ReturnUrl { get; set; }
    }
}
