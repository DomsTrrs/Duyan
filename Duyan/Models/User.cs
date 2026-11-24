using System.ComponentModel.DataAnnotations;

namespace Duyan.Models
{
    public class User
    {
        // Generated automatically by the database
        [Key]
        public int User_id { get; set; }

        public required int Hotel_id { get; set; }

        public required string Full_name { get; set; }

        public required string Email { get; set; }

        public required string Password_hash { get; set; }

        public required string role { get; set; }

        // Automatic: new users are active by default
        public bool is_active { get; set; } = true;

        // Automatic: set to the current time when the user is created
        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }
}