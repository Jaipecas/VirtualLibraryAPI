
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Application.Persistence.Services;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignUpFeature
    {
        public partial class SignUpCommandHandler : IRequestHandler<SignUpCommand, IActionResult>
        {
            private readonly IVirtualLibraryUnitOfWork _virtualLibraryUnitOfWork;
            private readonly IAuthService _authService;
            private readonly IMapper _mapper;

            public SignUpCommandHandler(IVirtualLibraryUnitOfWork virtualLibraryUnitOfWork, IAuthService authService, IMapper mapper)
            {
                _virtualLibraryUnitOfWork = virtualLibraryUnitOfWork;
                _authService = authService;
                _mapper = mapper;
            }

            public async Task<IActionResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
            {
                var user = new User { UserName = request.UserName, Email = request.Email };

                var identityResult = await _virtualLibraryUnitOfWork.Users.CreateAsync(user, request.Password);

                if (!identityResult.Succeeded) return new BadRequestObjectResult(identityResult.Errors);

                var result = _mapper.Map<SignUpDto>(user);

                var token = await _authService.GenerateJwtToken(user);

                _authService.SetAuthCookie(token!);

                return new OkObjectResult(result);
            }
        }
    }

}
