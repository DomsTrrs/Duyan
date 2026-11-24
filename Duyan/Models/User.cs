using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Duyan.Models
{
    public class User
    {
        [Key]
        public required int User_id { get; set; }

        public required int Hotel_id { get; set; }

        public required string Full_name { get; set; }

        public required string Email { get; set; }

        public required string Password_hash { get; set; }

        public required string role { get; set; }

        public required bool is_active { get; set; }

        public required DateTime created_at { get; set; }
    }
}
