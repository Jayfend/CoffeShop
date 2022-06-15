using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(100, ErrorMessage = "The user name must be less than {1} characters.")]

        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please write the subject.")]
        [MaxLength(100)]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please write your review")]
        [StringLength(1000, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        public string Message { get; set; }
    }
}
