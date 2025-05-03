using MediatR;
using VirtualLibrary.Application.Persistence.Services;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class LogoutFeature
    {
        public class LogOutHandler : IRequestHandler<LogoutCommand, Result<LogoutDto>>
        {
            private readonly IAuthService _authService;

            public LogOutHandler(IAuthService authService)
            {
                _authService = authService;
            }

            public async Task<Result<LogoutDto>> Handle(LogoutCommand request, CancellationToken cancellationToken)
            {
                _authService.RemoveAuthCookie();

                return await Task.FromResult(Result<LogoutDto>.Success(new LogoutDto { Message = "Logout succesfully"}));
            }
        }
    }
}
