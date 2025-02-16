using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence.Services;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class LogoutFeature
    {
        public class LogOutHandler : IRequestHandler<LogoutCommand, IActionResult>
        {
            private readonly IAuthService _authService;

            public LogOutHandler(IAuthService authService)
            {
                _authService = authService;
            }

            public async Task<IActionResult> Handle(LogoutCommand request, CancellationToken cancellationToken)
            {
                _authService.RemoveAuthCookie();

                return await Task.FromResult(new OkObjectResult(new { message = "User logged out successfully." }));
            }
        }
    }
}
