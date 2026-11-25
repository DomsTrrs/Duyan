
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
    }
}
