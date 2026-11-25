using Duyan.Models.ViewModels;
using Duyan.Services.Interfaces;
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
                // FIX: return the same view/model type the GET actions use
                // (assumes AuthPageViewModel has a SignUp property - adjust to yours)
                return View("Login", new AuthPageViewModel { ShowSignUp = true, SignUp = model });
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
                return View(new AuthPageViewModel { Login = model });
            }

            var user = await _authenticationService.AuthenticateAsync(model.Email, model.Password);

            if (user == null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Invalid email or password."
                );

                return View(new AuthPageViewModel { Login = model });
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
