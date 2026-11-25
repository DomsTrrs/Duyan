using Duyan.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Duyan.Models;
using Duyan.Models.ViewModels;

namespace Duyan.Controllers
{
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }


        // FIX: was open to anyone. Runs before every action in this controller.
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var role = HttpContext.Session.GetString("Role");
            var action = context.RouteData.Values["action"]?.ToString();

            // Create is the sign-up endpoint, so it must work before logging in
            if (action != "Create" && role != "Platform Administrator" && role != "Hotel Administrator")
            {
                context.Result = RedirectToAction("Login", "Account");
            }

            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> Index()  //CHANGABLE MORE ON FOR PLATFORM ADMIN MANAGING AND DELETING USERS
        {
            var users = await _context.User.ToListAsync();
            return View(users);
        }

        // GET: UserController/Create
        // FIX: this was missing, so there was no page to open the Create form
        [HttpGet]
        public IActionResult Create()
        {
            return RedirectToAction("Sign_Up", "Account");
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Account/Login.cshtml", new AuthPageViewModel { ShowSignUp = true, SignUp = model });
            }

            var email = model.Email.Trim().ToLower();

            // Is the email already taken?
            if (await _context.User.AnyAsync(u => u.Email == email))
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return View("~/Views/Account/Login.cshtml", new AuthPageViewModel { ShowSignUp = true, SignUp = model });
            }

            // Is the role allowed?
            var allowedRoles = new[] { "Hotel Staff", "Hotel Manager", "Platform Admin" };
            if (!allowedRoles.Contains(model.Role))
            {
                ModelState.AddModelError("Role", "Invalid role.");
                return View("~/Views/Account/Login.cshtml", new AuthPageViewModel { ShowSignUp = true, SignUp = model });
            }

            // The user is created HERE
            var user = new User
            {
                Hotel_id = model.Hotel_id,
                Full_name = model.Full_name,
                Email = email,
                Password_hash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                role = model.Role,
                is_active = true
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            // Account created - go to Login
            return RedirectToAction("Login", "Account");
        }

        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            // FIX: load the user so the form isn't empty
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {
            // Password isn't part of this form, don't fail validation because of it
            ModelState.Remove(nameof(Models.User.Password_hash));

            var email = user.Email.Trim().ToLower();

            // Check if email belongs to another user
            var existingUser = await _context.User
                .FirstOrDefaultAsync(u =>
                    u.Email == email &&
                    u.User_id != user.User_id);

            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return View(user);
            }

            if (ModelState.IsValid)
            {
                // FIX: update the real record field by field instead of _context.User.Update(user),
                // which overwrote Password_hash with an empty value.
                var dbUser = await _context.User.FindAsync(user.User_id);

                if (dbUser == null)
                {
                    return NotFound();
                }

                dbUser.Full_name = user.Full_name;
                dbUser.Email = email;
                dbUser.role = user.role;
                dbUser.is_active = user.is_active;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }


        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user != null)
            {
                _context.User.Remove(user);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
