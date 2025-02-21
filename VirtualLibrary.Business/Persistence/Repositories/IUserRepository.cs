
using Microsoft.AspNetCore.Identity;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<User?> FindByEmailAsync(string email);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<bool> CheckPasswordAsync(User user, string password);
    }
}
