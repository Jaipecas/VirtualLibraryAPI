
using Microsoft.AspNetCore.Identity;
using VirtualLibrary.Application.Persistence.Repositories;

namespace VirtualLibrary.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CheckPasswordAsync(IdentityUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> CreateAsync(IdentityUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityUser?> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
