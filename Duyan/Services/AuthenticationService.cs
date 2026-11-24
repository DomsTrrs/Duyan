using Duyan.Data;
using Duyan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Duyan.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthenticationService(ApplicationDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            // Find the user using their email
            var user = await _context.User
                .FirstOrDefaultAsync(u => u.Email == email);

            // Check if the user exists
            if (user == null)
            {
                return null;
            }

            // Check if the account is active
            if (!user.is_active)
            {
                return null;
            }

            // Verify the submitted password against the stored hash
            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.Password_hash,
                password
            );

            // Return the user if the password is correct
            if (result == PasswordVerificationResult.Success ||
                result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                return user;
            }

            // Invalid password
            return null;
        }
    }
}