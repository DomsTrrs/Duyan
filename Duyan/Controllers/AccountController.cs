using Duyan.Models;
using Duyan.Services;
using Microsoft.AspNetCore.Mvc;

namespace Duyan.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Account/Login
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        // GET: Account/Sign_Up
        public IActionResult Sign_Up()
        {
            return View(new SignUpViewModel());
        }

        // POST: Account/Sign_Up
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sign_Up(SignUpViewModel model)
        {
            // Check if form is valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Call UserService to register the user
            bool isRegistered = await _userService.SignUpAsync(model);

            // Check if registration was successful
            if (!isRegistered)
            {
                ModelState.AddModelError(
                    "Email",
                    "Email is already registered."
                );

                return View(model);
            }

            // Redirect to Login after successful signup
            return RedirectToAction(nameof(Login));
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}