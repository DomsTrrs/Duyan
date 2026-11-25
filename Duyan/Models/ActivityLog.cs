using System.ComponentModel.DataAnnotations;

namespace Duyan.Models
{
    // Audit trail of administrative actions (Platform Administrator "Activity Logs" page)
    public class ActivityLog
    {
        [Key]
        public int Log_id { get; set; }

        // Who did it (null for system actions)
        public int? User_id { get; set; }

        public required string Actor_name { get; set; }

        public required string Action { get; set; }

        public string? Details { get; set; }

        // Hotel the action relates to, if any
        public int? Hotel_id { get; set; }

        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }
}