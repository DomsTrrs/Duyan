using System.ComponentModel.DataAnnotations;

namespace Duyan.Models
{
    public class LoginViewModel
    {
        // Text box 1
        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        // Text box 2
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        // Message shown after the Login button is clicked
        public string Message { get; set; } = string.Empty;

        // Login button logic
        public bool Login()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                Message = "Please enter your username and password.";
                return false;
            }

            // TODO: replace with a real database check using hashed passwords.
            if (Email == "admin" && Password == "password123")
            {
                Message = "Login successful.";
                return true;
            }

            Message = "Invalid username or password.";
            return false;
        }
    }
}