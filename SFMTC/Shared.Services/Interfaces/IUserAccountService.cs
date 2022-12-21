using Shared.Interfaces.User;

namespace Shared.Services.Interfaces
{
    public interface IUserAccountService
    {
        Task<bool> IsUserLoggedIn(string url, Guid userId);
        Task<IUser> LoginAsync(string url, ILogin login);
        Task<bool> LogoutAsync(string url, Guid userId);
    }
}
