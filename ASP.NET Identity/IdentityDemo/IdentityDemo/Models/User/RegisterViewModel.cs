using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IdentityDemo.Models.User
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(20, MinimumLength = 5)]
        public string Email { get; set; } = null!;
    }
}
