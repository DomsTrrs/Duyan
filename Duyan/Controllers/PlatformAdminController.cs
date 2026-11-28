using Duyan.Data;
using Duyan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Duyan.Controllers
{
    public class PlatformAdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PlatformAdminController(ApplicationDbContext db)
        {
            _db = db;
        }

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

        [HttpGet]
        public async Task<IActionResult> HotelManagement()
        {
            if (!IsPlatformAdmin())
                return RedirectToAction("Login", "Account");

            var hotels = await _db.Hotel
                .OrderByDescending(h => h.created_at)
                .ToListAsync();

            return View(hotels);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterHotel(
            [Bind("Hotel_name,Address,City,Contact_number,email,Check_in_time,Check_out_time,Policies,Amenities")] Hotel hotel)
        {
            if (!IsPlatformAdmin())
                return RedirectToAction("Login", "Account");

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please check the hotel details and try again.";
                return RedirectToAction(nameof(HotelManagement));
            }

            hotel.Status = HotelStatus.Active;   // use HotelStatus.Pending if an approval step follows
            _db.Hotel.Add(hotel);
            await _db.SaveChangesAsync();

            TempData["Success"] = $"{hotel.Hotel_name} was registered.";
            return RedirectToAction(nameof(HotelManagement));
        }

        public IActionResult ActivityLogs()
        {
            if (!IsPlatformAdmin())
                return RedirectToAction("Login", "Account");

            return View();
        }
    }
}