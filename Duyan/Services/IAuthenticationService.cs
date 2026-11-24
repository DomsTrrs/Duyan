using Duyan.Models;

namespace Duyan.Services
{
    public interface IAuthenticationService
    {
        Task<User?> AuthenticateAsync(string email, string password);
    }
}