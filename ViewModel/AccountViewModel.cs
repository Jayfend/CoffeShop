using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "Please enter the user name.")]
        [StringLength(50, ErrorMessage = "The user name must be less than {1} characters.")]
        
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
       
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        
        public string ConfirmPassword { get; set; }
    
        [ScaffoldColumn(false)]
        public string ReturnUrl { get; set; }
       
    }
}
