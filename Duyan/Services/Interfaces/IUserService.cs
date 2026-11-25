namespace Duyan.Services.Interfaces
{
    public interface IUserService
    {
        // Decides which page a user lands on after logging in, based on their role
        (string Controller, string Action) GetHomeRoute(string role);
    }
}