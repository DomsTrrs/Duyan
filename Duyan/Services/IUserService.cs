using Duyan.Models;

namespace Duyan.Services
{
    public interface IUserService
    {
        Task<bool> SignUpAsync(SignUpViewModel model);

        Task<bool> EmailExistsAsync(string email);
    }
}