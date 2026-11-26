using Microsoft.AspNetCore.Mvc;

namespace Duyan.Controllers
{
    public class PlatformAdminController : Controller
    {
        // Same check you already use, shared by every Platform Admin page
        private bool IsPlatformAdmin()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var role = HttpContext.Session.GetString("Role");
            return userId != null && role == "Platform Admin";
        }

        public IActionResult Dashboard()
        {
            if (!IsPlatformAdmin())
                return RedirectToAction("Login", "Account");

            return View();
        }

        public IActionResult HotelManagement()
        {
            if (!IsPlatformAdmin())
                return RedirectToAction("Login", "Account");

            return View();
        }

        public IActionResult ActivityLogs()
        {
            if (!IsPlatformAdmin())
                return RedirectToAction("Login", "Account");

            return View();
        }
    }
}