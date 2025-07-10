using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoocModel
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="User Name is required")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage ="Email is invaild")]
        public string? Email { get; set; }

        [PhoneValidation]
        public string? Phone { get; set; }

        public GenderEnum Gender { get; set; }

        [StringLength(50, MinimumLength = 10, ErrorMessage = "Address must be between 10 and 50 characters")]
        public string? Address { get; set; }

        [Required]
        [MaxLength(10)]
        public string Password { get; set; }

    }
}
