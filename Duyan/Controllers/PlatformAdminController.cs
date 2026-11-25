using Duyan.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Duyan.Controllers
{
    [Authorize(Roles = Roles.PlatformAdmin)]
    public class PlatformAdminController : Controller
    {
        // GET: PlatformAdmin/Dashboard
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}