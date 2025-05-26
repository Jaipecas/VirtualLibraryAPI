using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Persistence.Services
{
    public interface IAuthService
    {
        Task<string?> GenerateJwtToken(User user);
        void SetAuthCookie(string token);
        void RemoveAuthCookie();
    }
}
