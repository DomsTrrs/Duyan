using Microsoft.AspNetCore.Mvc;

namespace Duyan.Controllers
{
    public class HotelManagerController : Controller
    {
        public IActionResult Hotel_Manager()
        {
            return View();
        }
    }
}