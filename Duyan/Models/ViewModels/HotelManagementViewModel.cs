
using System.ComponentModel.DataAnnotations;

namespace Duyan.Models.ViewModels
{
    public class HotelManagementViewModel
    {
        [Required(ErrorMessage = "Hotel name is required.")]
        public string Hotel_name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact number is required.")]
        public string Contact_number { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hotel email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string email { get; set; } = string.Empty;

        [Required]
        public TimeSpan Check_in_time { get; set; }

        [Required]
        public TimeSpan Check_out_time { get; set; }

        public string? Policies { get; set; }

        public string? Amenities { get; set; }
    }
}
