using Duyan.Data;
using Duyan.Models;
using Duyan.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Duyan.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // REGISTER
        public async Task<bool> SignUpAsync(SignUpViewModel model)
        {
            if (await EmailExistsAsync(model.Email))
            {
                return false;
            }

            var user = new User
            {
                Hotel_id = model.Hotel_id,
                Full_name = model.Full_name,
                Email = model.Email,
                Password_hash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                role = "Hotel Staff"
            };

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return true;
        }

        // CHECK EMAIL
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.User
                .AnyAsync(u => u.Email == email);
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