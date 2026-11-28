using Duyan.Data;
using Duyan.Models;
using Duyan.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Duyan.Controllers
{
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hotel/Create
        public IActionResult Create()
        {
            return RedirectToAction("HotelManagement", "PlatformAdmin");
        }

        // POST: Hotel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HotelManagementViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/PlatformAdmin/HotelManagement.cshtml", model);
            }

            var hotel_name = model.Hotel_name.Trim();

            if (await _context.Hotel.AnyAsync(h => h.Hotel_name.ToLower() == hotel_name.ToLower()))
            {
                ModelState.AddModelError("Hotel_name", "Hotel name already exists.");
                return View("~/Views/PlatformAdmin/HotelManagement.cshtml", model);
            }

            var hotel = new Hotel
            {
                Hotel_name = hotel_name,
                Address = model.Address,
                City = model.City,
                Contact_number = model.Contact_number,
                email = model.email,
                Check_in_time = model.Check_in_time,
                Check_out_time = model.Check_out_time,
                Policies = model.Policies,
                Amenities = model.Amenities,
                Status = HotelStatus.Pending,
                created_at = DateTime.UtcNow
            };

            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();

            return RedirectToAction("HotelManagement", "PlatformAdmin");
        }

        // POST: Hotel/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Hotel hotel)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(hotel.Hotel_name))
            {
                TempData["Error"] = "Please fill in all required fields.";
                return RedirectToAction("HotelManagement", "PlatformAdmin");
            }

            var hotel_name = hotel.Hotel_name.Trim();

            // Does another hotel already use this name?
            bool nameTaken = await _context.Hotel.AnyAsync(h =>
                h.Hotel_name.ToLower() == hotel_name.ToLower() &&
                h.Hotel_id != hotel.Hotel_id);

            if (nameTaken)
            {
                TempData["Error"] = "Hotel name already exists.";
                return RedirectToAction("HotelManagement", "PlatformAdmin");
            }

            var dbHotel = await _context.Hotel.FindAsync(hotel.Hotel_id);

            if (dbHotel == null)
            {
                return NotFound();
            }

            dbHotel.Hotel_name = hotel_name;
            dbHotel.Address = hotel.Address;
            dbHotel.City = hotel.City;
            dbHotel.Contact_number = hotel.Contact_number;
            dbHotel.email = hotel.email;
            dbHotel.Check_in_time = hotel.Check_in_time;
            dbHotel.Check_out_time = hotel.Check_out_time;
            dbHotel.Policies = hotel.Policies;
            dbHotel.Amenities = hotel.Amenities;

            await _context.SaveChangesAsync();

            return RedirectToAction("HotelManagement", "PlatformAdmin");
        }

        // POST: Hotel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Hotel_id)
        {
            var hotel = await _context.Hotel.FindAsync(Hotel_id);

            if (hotel != null)
            {
                _context.Hotel.Remove(hotel);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("HotelManagement", "PlatformAdmin");
        }
    }
}