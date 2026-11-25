using Duyan.Models.ViewModels;
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
            return View(new AuthPageViewModel());
        }

        // GET: Account/Sign_Up
        [HttpGet]
        public IActionResult Sign_Up()
        {
            return View("Login", new AuthPageViewModel { ShowSignUp = true });
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

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isLoggedIn = await _userService.LoginAsync(model);

            if (!isLoggedIn)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Invalid email or password."
                );

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}