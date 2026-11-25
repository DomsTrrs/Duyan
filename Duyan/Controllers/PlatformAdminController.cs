using Microsoft.AspNetCore.Mvc;

namespace Duyan.Controllers
{
    public class PlatformAdminController : Controller
    {
        // Dashboard
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
            if (!IsPlatformAdmin())
                return RedirectToAction("Login", "Account");

            return View();
        }

        // Hotels
        public IActionResult RegisteredHotels()
        {
            if (!IsPlatformAdmin())
                return RedirectToAction("Login", "Account");

            return View();
        }

        // Hotel Administrators
        public IActionResult HotelAdministrators()
        {
            if (!IsPlatformAdmin())
                return RedirectToAction("Login", "Account");

            return View();
        }

        // Activity Logs
        public IActionResult ActivityLogs()
        {
            if (!IsPlatformAdmin())
                return RedirectToAction("Login", "Account");

            return View();
        }

        // Check if the user is a Platform Admin
        private bool IsPlatformAdmin()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var role = HttpContext.Session.GetString("Role");

            return userId != null && role == "Platform Admin";
        }
    }
}