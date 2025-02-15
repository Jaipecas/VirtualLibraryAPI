using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VirtualLibrary.Application.Persistence.Services;

namespace VirtualLibrary.Persistence.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string?> GenerateJwtToken(IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Email, user.Email!),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

            var token = new JwtSecurityToken(
                             issuer: _configuration["JWT:ValidIssuer"],
                             audience: _configuration["JWT:ValidAudience"],
                             expires: DateTime.UtcNow.AddHours(Double.Parse(_configuration["JWT:ExpirationInHours"]!)),
                             claims: authClaims,
                             signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
