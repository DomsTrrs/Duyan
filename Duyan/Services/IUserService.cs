using Duyan.Models.ViewModels;

namespace Duyan.Services
{
    public interface IUserService
    {
        Task<bool> SignUpAsync(SignUpViewModel model);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> LoginAsync(LoginViewModel model);
    }
}