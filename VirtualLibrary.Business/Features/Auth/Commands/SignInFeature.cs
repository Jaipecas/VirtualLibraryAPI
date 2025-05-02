
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Application.Persistence.Services;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignInFeature
    {
        public class SignInHandler : IRequestHandler<SignInCommand, Result<SignInDto>>
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

            public async Task<Result<SignInDto>> Handle(SignInCommand request, CancellationToken cancellationToken)
            {
                var user = await _virtualLibraryUnitOfWork.Users.FindByEmailAsync(request.Email);

                if (user == null) return Result<SignInDto>.Failure("Invalid login credentials: user not exist");

                var isUser = await _virtualLibraryUnitOfWork.Users.CheckPasswordAsync(user, request.Password);

                if (isUser == false) return Result<SignInDto>.Failure("Invalid login credentials: incorrect password");

                var result = _mapper.Map<SignInDto>(user);

                var token = await _authService.GenerateJwtToken(user);

                _authService.SetAuthCookie(token!);

                return Result<SignInDto>.Success(result);
            }
        }
    }
}
