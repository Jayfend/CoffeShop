using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ProfileViewModel
    {

        [Required(ErrorMessage = "Please enter your full name.")]
        [StringLength(50, ErrorMessage = "Your full name must be less than {1} characters.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter your address.")]
        [StringLength(150, ErrorMessage = "Your Address must be less than {1} characters.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone Number Required!")]
        
        public string PhoneNumber { get; set; }
        
        
        public byte[] Image { get; set; }
    }
}
