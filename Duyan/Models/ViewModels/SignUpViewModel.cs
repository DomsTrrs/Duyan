using System.ComponentModel.DataAnnotations;

namespace Duyan.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Full name is required.")]
        [Display(Name = "Full name")]
        public string Full_name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hotel ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid Hotel ID.")]
        [Display(Name = "Hotel ID")]
        public int Hotel_id { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        [Display(Name = "Role")]
        public string Role { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}