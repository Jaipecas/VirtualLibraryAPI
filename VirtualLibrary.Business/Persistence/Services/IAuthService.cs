
using Microsoft.AspNetCore.Identity;

namespace VirtualLibrary.Application.Persistence.Services
{
    public interface IAuthService
    {
        Task<string?> GenerateJwtToken(IdentityUser user);
    }
}
