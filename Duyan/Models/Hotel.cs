using System.ComponentModel.DataAnnotations;

namespace Duyan.Models
{
    public class Hotel
    {
        [Key]
        public int Hotel_id { get; set; }

        public required string Hotel_name { get; set; }

        public required string Address { get; set; }

        public required string City { get; set; }

        public required string Contact_number { get; set; }

        public required string email { get; set; }

        // Standard check-in / check-out times shown on the hotel profile
        public TimeSpan Check_in_time { get; set; } 

        public TimeSpan Check_out_time { get; set; } 

        public string? Policies { get; set; }

        public string? Amenities { get; set; }

        // Pending, Active, Suspended, Deactivated, Rejected (see HotelStatus below)
        public string Status { get; set; } = HotelStatus.Active;

        // Reason written by the Platform Administrator when rejecting an application
        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }

    public static class HotelStatus
    {
        
        public const string Active = "Active";
        public const string Suspended = "Suspended";
        public const string Deactivated = "Deactivated";
        public const string Rejected = "Rejected";
    }
}