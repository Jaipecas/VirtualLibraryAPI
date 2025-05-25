
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Application.Persistence.Services;
using VirtualLibrary.Domain;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignUpFeature
    {
        public partial class SignUpCommandHandler : IRequestHandler<SignUpCommand, Result<SignUpDto>>
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

            public async Task<Result<SignUpDto>> Handle(SignUpCommand request, CancellationToken cancellationToken)
            {
                var user = new User { UserName = request.UserName, Email = request.Email, Logo = request.Logo };

                var userEmail = await _virtualLibraryUnitOfWork.Users.FindByEmailAsync(user.Email);

                if (userEmail != null) return Result<SignUpDto>.Failure("Email already exist");

                var identityResult = await _virtualLibraryUnitOfWork.Users.CreateAsync(user, request.Password);

                if (!identityResult.Succeeded) return Result<SignUpDto>.Failure(identityResult.Errors.Select(e => e.Description).ToList());

                var result = _mapper.Map<SignUpDto>(user);

                var token = await _authService.GenerateJwtToken(user);

                _authService.SetAuthCookie(token!);

                return Result<SignUpDto>.Success(result);
            }
        }
    }

}
