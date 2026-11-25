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

            return View();
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

            return View();
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

            return View();
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

            return View();
        }
    }
}