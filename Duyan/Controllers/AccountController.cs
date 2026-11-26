
using Duyan.Models.ViewModels;
using Duyan.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Duyan.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View(new AuthPageViewModel());
        }

        // GET: Account/Sign_Up
        [HttpGet]
        public IActionResult Sign_Up()
        {
            return View("Login", new AuthPageViewModel
            {
                ShowSignUp = true
            });
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(new AuthPageViewModel { Login = model });
            }

            var user = await _authenticationService.AuthenticateAsync(
                model.Email,
                model.Password
            );

            if (user == null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Invalid email or password."
                );

                return View(new AuthPageViewModel { Login = model });
            }

            // Check whether the user's role is recognized.
            if (user.role != "Platform Admin" &&
                user.role != "Hotel Manager" &&
                user.role != "Hotel Staff")
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Your account role is not recognized."
                );

                return View(new AuthPageViewModel { Login = model });
            }

            // Store user information in Session.
            HttpContext.Session.SetInt32("UserId", user.User_id);
            HttpContext.Session.SetString("FullName", user.Full_name);
            HttpContext.Session.SetString("Role", user.role);
            HttpContext.Session.SetString(
                "HotelId",
                user.Hotel_id?.ToString() ?? string.Empty
            );

            // Redirect based on the user's role.
            switch (user.role)
            {
                case "Platform Admin":
                    return RedirectToAction("Dashboard", "PlatformAdmin");

                case "Hotel Manager":
                    return RedirectToAction("Hotel_Manager", "HotelManager");

                case "Hotel Staff":
                    return RedirectToAction("Hotel_Staff", "HotelStaff");

                default:
                    HttpContext.Session.Clear();
                    return RedirectToAction("Login");
            }
        }

        // POST: Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
