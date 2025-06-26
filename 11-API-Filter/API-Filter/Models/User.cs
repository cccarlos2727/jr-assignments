using API_Filter.ViewModel;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace API_Filter.Models
{
    public class User
    {
        
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Username must not be null.")]
        public string? UserName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [RegularExpression(@"^\+61\s?4\d{2}[- ]?\d{3}[- ]?\d{3}$")]
        public string Phone { get; set; }

        public GenderEnum Gender { get; set; }

        [AddressValidation(10, 50)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [PasswordValidation(10)]
        public string? Password { get; set; }
    }
}
