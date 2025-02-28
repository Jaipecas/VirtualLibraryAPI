
using Microsoft.AspNetCore.Identity;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<User?> FindByEmailAsync(string email);
        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);
        Task<IdentityResult> UpdateAsync(User user);
        Task<User?> FindByNameAsync(string userName);
    }
}
