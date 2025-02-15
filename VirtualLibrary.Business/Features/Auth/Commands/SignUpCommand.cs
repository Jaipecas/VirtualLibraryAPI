
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Application.Persistence.Services;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public class SignUpCommand : IRequest<IActionResult>
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class SignUpValidation : AbstractValidator<SignUpCommand>
    {
        public SignUpValidation()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }

    public class SignUpDto
    {
        public required string Token { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
    }

    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _virtualLibraryUnitOfWork ;
        private readonly IAuthService _authService;

        public SignUpCommandHandler(IVirtualLibraryUnitOfWork virtualLibraryUnitOfWork, IAuthService authService)
        {
            _virtualLibraryUnitOfWork = virtualLibraryUnitOfWork;
            _authService = authService;
        }

        public async Task<IActionResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var user = new IdentityUser { UserName = request.Email, Email = request.Email };
            var result = await _virtualLibraryUnitOfWork.Users.CreateAsync(user, request.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(result.Errors);

            var token = await _authService.GenerateJwtToken(user);

            return new OkObjectResult(new SignUpDto { UserName = request.UserName, Email = request.Email, Token = token! });
        }
    }
}
