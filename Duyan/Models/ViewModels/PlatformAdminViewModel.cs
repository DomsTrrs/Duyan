using System.ComponentModel.DataAnnotations;

namespace Duyan.Models.ViewModels
{
    public record ServiceResult(bool Success, string Message);

    public class HotelOption
    {
        public int Hotel_id { get; set; }
        public string Hotel_name { get; set; } = string.Empty;
    }

    // ---------- Dashboard ----------
    public class PlatformDashboardViewModel
    {
        public int TotalHotels { get; set; }
        public int ActiveHotels { get; set; }
        public int PendingApplications { get; set; }
        public int SuspendedHotels { get; set; }
        public int DeactivatedHotels { get; set; }
        public int RejectedApplications { get; set; }
        public int TotalHotelAdmins { get; set; }
        public int TotalStaff { get; set; }
        public List<HotelRowViewModel> RecentRequests { get; set; } = new();
        public List<ActivityLog> RecentActivity { get; set; } = new();
    }

    // ---------- Hotels ----------
    public class HotelRowViewModel
    {
        public int Hotel_id { get; set; }
        public string Hotel_name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Contact_number { get; set; } = string.Empty;
        public string Contact_email { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? Review_notes { get; set; }
        public DateTime created_at { get; set; }
        public string? AdminName { get; set; }
        public string? AdminEmail { get; set; }
        public int StaffCount { get; set; }
    }

    public class HotelListViewModel
    {
        public List<HotelRowViewModel> Hotels { get; set; } = new();
        public string? Status { get; set; }
        public string? Search { get; set; }
    }

    public class RequestsViewModel
    {
        public List<HotelRowViewModel> Pending { get; set; } = new();
        public List<HotelRowViewModel> Rejected { get; set; } = new();
    }

    public class HotelDetailsViewModel
    {
        public Hotel Hotel { get; set; } = null!;
        public List<Duyan.Models.User> Admins { get; set; } = new();
        public int StaffCount { get; set; }
        public List<ActivityLog> Logs { get; set; } = new();
    }

    public class HotelEditViewModel
    {
        public int Hotel_id { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Hotel name")]
        public string Hotel_name { get; set; } = string.Empty;

        [Required, StringLength(250)]
        public string Address { get; set; } = string.Empty;

        [Required, StringLength(40)]
        [Display(Name = "Contact number")]
        public string Contact_number { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(150)]
        [Display(Name = "Contact email")]
        public string Contact_email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Check-in time")]
        public TimeSpan Check_in_time { get; set; }

        [Required]
        [Display(Name = "Check-out time")]
        public TimeSpan Check_out_time { get; set; }

        public string? Policies { get; set; }

        public string? Amenities { get; set; }
    }

    public class StatusActionModel
    {
        public int Hotel_id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string From { get; set; } = "list";
    }

    // ---------- Accounts ----------
    public class AccountRowViewModel
    {
        public int User_id { get; set; }
        public string Full_name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool Is_active { get; set; }
        public DateTime Created_at { get; set; }
        public int? Hotel_id { get; set; }
        public string? Hotel_name { get; set; }
    }

    public class AccountsViewModel
    {
        public List<AccountRowViewModel> Accounts { get; set; } = new();
        public string? Search { get; set; }
    }

    public class AdminAccountFormViewModel
    {
        public int User_id { get; set; }

        [Required, StringLength(120)]
        [Display(Name = "Full name")]
        public string Full_name { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a hotel.")]
        [Display(Name = "Assigned hotel")]
        public int? Hotel_id { get; set; }

        // Only required when creating a new account
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
        public string? Password { get; set; }

        public bool IsEdit => User_id > 0;

        public List<HotelOption> Hotels { get; set; } = new();
    }

    // ---------- Reports ----------
    public class ReportsViewModel
    {
        public Dictionary<string, int> HotelsByStatus { get; set; } = new();
        public List<KeyValuePair<string, int>> RegistrationsPerMonth { get; set; } = new();
        public Dictionary<string, int> UsersByRole { get; set; } = new();
        public List<KeyValuePair<string, int>> TopHotelsByStaff { get; set; } = new();
        public int TotalRooms { get; set; }
        public int TotalReservations { get; set; }
    }

    // ---------- Logs ----------
    public class LogsViewModel
    {
        public List<ActivityLog> Logs { get; set; } = new();
        public string? Search { get; set; }
        public int Page { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalCount { get; set; }
    }

    // ---------- Profile ----------
    public class ProfileViewModel
    {
        [Required, StringLength(120)]
        [Display(Name = "Full name")]
        public string Full_name { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; } = string.Empty;
    }

    public class ChangePasswordViewModel
    {
        [Required, DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required, DataType(DataType.Password), StringLength(100, MinimumLength = 8)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match.")]
        [Display(Name = "Confirm new password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    public class ProfilePageViewModel
    {
        public ProfileViewModel Profile { get; set; } = new();
        public ChangePasswordViewModel Password { get; set; } = new();
    }
}
