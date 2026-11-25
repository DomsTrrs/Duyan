using Duyan.Models;
using Duyan.Services.Interfaces;

namespace Duyan.Services
{
    public class UserService : IUserService
    {
        public (string Controller, string Action) GetHomeRoute(string role)
        {
            if (string.Equals(role, Roles.PlatformAdmin, StringComparison.OrdinalIgnoreCase))
                return ("PlatformAdmin", "Dashboard");

            // Next steps: add Hotel Administrator and Hotel Staff here, for example
            // if (string.Equals(role, AppRoles.HotelAdmin, StringComparison.OrdinalIgnoreCase))
            //     return ("HotelAdmin", "Index");

            // Everyone else goes to the current default page for now
            return ("Home", "Index");
        }
    }
}