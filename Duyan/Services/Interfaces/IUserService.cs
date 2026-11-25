using Duyan.Models;
using Duyan.Models.ViewModels;

namespace Duyan.Services.Interfaces
{
    public interface IUserService
    {
        Task<(User? User, string? Error)> PrepareUserAsync(SignUpViewModel model);
        Task<bool> EmailExistsAsync(string email);
        Task<string?> SignUpAsync(SignUpViewModel model);
    }
}