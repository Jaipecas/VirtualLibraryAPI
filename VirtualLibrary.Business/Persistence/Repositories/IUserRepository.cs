
using Microsoft.AspNetCore.Identity;

namespace VirtualLibrary.Application.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityUser?> FindByEmailAsync(string email);
        Task<IdentityResult> CreateAsync(IdentityUser user, string password);
        Task<bool> CheckPasswordAsync(IdentityUser user, string password);
    }
}
