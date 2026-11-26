using Duyan.Data;
using Duyan.Models;
using Duyan.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Duyan.Services.Interfaces;

namespace Duyan.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApplicationDbContext _context;


        public AuthenticationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            email = email.Trim().ToLower();

            var user = await _context.User
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !user.is_active)
            {
                return null;
            }

            // BCrypt, same as sign-up
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password_hash))
            {
                return null;
            }

            return user;
        }

        // LOGIN
        public async Task<bool> LoginAsync(LoginViewModel model)
        {
            // Find user by email
            var user = await _context.User
                .FirstOrDefaultAsync(u => u.Email == model.Email);

            // Check if user exists
            if (user == null)
            {
                return false;
            }

            // Verify password
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(
                model.Password,
                user.Password_hash
            );

            if (!isPasswordValid)
            {
                return false;
            }

            return true;
        }

    }
}
