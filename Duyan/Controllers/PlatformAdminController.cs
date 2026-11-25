using Microsoft.AspNetCore.Mvc;

namespace Duyan.Controllers
{
    public class PlatformAdminController : Controller
    {
        public IActionResult Dashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var role = HttpContext.Session.GetString("Role");

            if (userId == null || role != "Platform Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // Registration Requests
        public IActionResult HotelApplications()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var role = HttpContext.Session.GetString("Role");

            if (userId == null || role != "Platform Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            return View("ComingSoon", "Registration Requests");
        }

        // Hotels
        public IActionResult RegisteredHotels()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var role = HttpContext.Session.GetString("Role");

            if (userId == null || role != "Platform Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            return View("ComingSoon", "Hotels");
        }

        // Hotel Administrators
        public IActionResult HotelAdministrators()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var role = HttpContext.Session.GetString("Role");

            if (userId == null || role != "Platform Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            return View("ComingSoon", "Hotel Administrators");
        }

        // Activity Logs
        public IActionResult ActivityLogs()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var role = HttpContext.Session.GetString("Role");

            if (userId == null || role != "Platform Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            return View("ComingSoon", "Activity Logs");
        }
    }
}