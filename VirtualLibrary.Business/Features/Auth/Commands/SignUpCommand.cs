
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
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

    public class SignUpProfile : Profile
    {
        public SignUpProfile()
        {
            CreateMap<IdentityUser, SignUpDto>();
        }
    }

    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, IActionResult>
    {
        private readonly IVirtualLibraryUnitOfWork _virtualLibraryUnitOfWork ;
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
            var user = new IdentityUser { UserName = request.UserName, Email = request.Email };
            var identityResult = await _virtualLibraryUnitOfWork.Users.CreateAsync(user, request.Password);

            if (!identityResult.Succeeded) return new BadRequestObjectResult(identityResult.Errors);

            var result = _mapper.Map<IdentityUser, SignUpDto>(user);

            var token = await _authService.GenerateJwtToken(user);

            result.Token = token!;

            return new OkObjectResult(result);
        }
    }
}
