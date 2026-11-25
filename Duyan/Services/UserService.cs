using Duyan.Data;
using Duyan.Models;
using Duyan.Models.ViewModels;
using Duyan.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Duyan.Services
{
    public class UserService : IUserService
    {
        // FIX: _context didn't exist, so the class didn't compile
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(User? User, string? Error)> PrepareUserAsync(SignUpViewModel model)
        {
            var email = model.Email.Trim().ToLower();

            if (await EmailExistsAsync(email))
            {
                return (null, "Email already exists.");
            }

            var allowedRoles = new[] { "Hotel Staff", "Hotel Manager" };
            if (!allowedRoles.Contains(model.Role))
            {
                return (null, "Invalid role.");
            }

            var user = new User
            {
                Hotel_id = model.Hotel_id,
                Full_name = model.Full_name,
                Email = email,
                Password_hash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                role = model.Role,
                is_active = true
            };

            return (user, null);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            email = email.Trim().ToLower();
            return await _context.User.AnyAsync(u => u.Email == email);
        }

        // Validates, builds, AND saves. Used by AccountController.
        public async Task<string?> SignUpAsync(SignUpViewModel model)
        {
            // FIX: reuse PrepareUserAsync (same checks) and actually save the user.
            // Before, this only validated and returned null, so nothing was ever saved.
            var (user, error) = await PrepareUserAsync(model);

            if (error != null)
                return error;

            _context.User.Add(user!);
            await _context.SaveChangesAsync();

            return null;
        }

    }
}