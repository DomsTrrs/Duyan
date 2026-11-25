
using Duyan.Models;
using Duyan.Services.Interfaces;

namespace Duyan.Services
{
    public class UserService : IUserService
    {
        public (string Controller, string Action) GetHomeRoute(string role)
        {
            // Platform Admin
            if (string.Equals(role, Roles.PlatformAdmin, StringComparison.OrdinalIgnoreCase))
                return ("PlatformAdmin", "Dashboard");

            // Hotel Admin
            if (string.Equals(role, Roles.HotelAdmin, StringComparison.OrdinalIgnoreCase))
                return ("HotelAdmin", "Dashboard");

            // Hotel Staff
            if (string.Equals(role, Roles.HotelStaff, StringComparison.OrdinalIgnoreCase))
                return ("HotelStaff", "Dashboard");

            // Default route
            return ("Home", "Index");
        }
    }
}
