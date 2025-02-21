
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Application.Persistence.Services;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignInFeature
    {
        public class SignInHandler : IRequestHandler<SignInCommand, IActionResult>
        {
            private readonly IVirtualLibraryUnitOfWork _virtualLibraryUnitOfWork;
            private readonly IAuthService _authService;
            private readonly IMapper _mapper;

            public SignInHandler(IVirtualLibraryUnitOfWork virtualLibraryUnitOfWork, IAuthService authService, IMapper mapper)
            {
                _virtualLibraryUnitOfWork = virtualLibraryUnitOfWork;
                _authService = authService;
                _mapper = mapper;
            }

            public async Task<IActionResult> Handle(SignInCommand request, CancellationToken cancellationToken)
            {
                var user = await _virtualLibraryUnitOfWork.Users.FindByEmailAsync(request.Email);

                if (user == null) return new UnauthorizedObjectResult(new { errorMessage = "Invalid login credentials" });

                var isUser = await _virtualLibraryUnitOfWork.Users.CheckPasswordAsync(user, request.Password);

                if (isUser == false) return new UnauthorizedObjectResult(new { errorMessage = "Invalid login credentials" });

                var result = _mapper.Map<SignInDto>(user);

                var token = await _authService.GenerateJwtToken(user);

                _authService.SetAuthCookie(token!);

                return new OkObjectResult(result);
            }
        }
    }
}
