using Duyan.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Duyan.Models;
using Duyan.Models.ViewModels;
using Duyan.Services.Interfaces;

namespace Duyan.Controllers
{
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public UserController(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }


        // FIX: was open to anyone. Runs before every action in this controller.
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var role = HttpContext.Session.GetString("Role");

            if (role != "Platform Administrator" && role != "Hotel Administrator")
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

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // SignUpAsync now validates AND saves the user
            var error = await _userService.SignUpAsync(model);

            if (error != null)
            {
                ModelState.AddModelError("Email", error);
                return View(model);
            }

                // FIX: removed the manual "new User { ... }" + SaveChanges block.
                // It inserted the same user a second time.

            return RedirectToAction(nameof(Index));
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