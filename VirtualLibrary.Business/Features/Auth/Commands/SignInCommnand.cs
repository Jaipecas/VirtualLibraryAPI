
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Application.Persistence.Services;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public class SignInCommnand : IRequest<IActionResult>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class SignInValidation : AbstractValidator<SignInCommnand>
    {

        public SignInValidation()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }

    public class SignInDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Token { get; set; }
    }

    public class SignInProfile : Profile
    {
        public SignInProfile()
        {
            CreateMap<IdentityUser, SignInDto>();
        }
    }

    public class SignInHandler : IRequestHandler<SignInCommnand, IActionResult>
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

        public async Task<IActionResult> Handle(SignInCommnand request, CancellationToken cancellationToken)
        {
            var user = await _virtualLibraryUnitOfWork.Users.FindByEmailAsync(request.Email);

            if (user == null) return new UnauthorizedObjectResult("Invalid login credentials");

            var isUser = await _virtualLibraryUnitOfWork.Users.CheckPasswordAsync(user, request.Password);

            if (isUser == false) return new UnauthorizedObjectResult("Invalid login credentials");

            var result = _mapper.Map<IdentityUser, SignInDto>(user);

            var token = await _authService.GenerateJwtToken(user);

            result.Token = token!;

            return new OkObjectResult(result);
        }
    }
}
