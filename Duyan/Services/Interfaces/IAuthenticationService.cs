using Duyan.Models;
using Duyan.Models.ViewModels;
namespace Duyan.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<User?> AuthenticateAsync(string email, string password);
        Task<bool> LoginAsync(LoginViewModel model);
    }
}