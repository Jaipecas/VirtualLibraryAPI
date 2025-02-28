using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;
using VirtualLibrary.Domain;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class UpdateUserFeature
    {
        public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, IActionResult>
        {
            private readonly IVirtualLibraryUnitOfWork _virtualLibraryUnitOfWork;
            private readonly IMapper _mapper;
            private readonly IPasswordHasher<User> _passwordHasher;

            public UpdateUserHandler(IVirtualLibraryUnitOfWork virtualLibraryUnitOfWork, IMapper mapper, IPasswordHasher<User> passwordHasher)
            {
                _virtualLibraryUnitOfWork = virtualLibraryUnitOfWork;
                _mapper = mapper;
                _passwordHasher = passwordHasher;
            }

            public async Task<IActionResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _virtualLibraryUnitOfWork.Users.FindByEmailAsync(request.CurrentEmail);

                if (user == null) return new UnauthorizedObjectResult(new { errorMessage = "Invalid user" });

                if (!string.IsNullOrEmpty(request.NewEmail))
                {
                    var newUser = await _virtualLibraryUnitOfWork.Users.FindByEmailAsync(request.NewEmail);

                    if (newUser != null && request.NewEmail != user.Email) return new BadRequestObjectResult(new { errorMessage = "Email ya existe" });

                    user.Email = request.NewEmail;
                }

                if (!string.IsNullOrEmpty(request.NewUserName))
                {
                    var newUserName = await _virtualLibraryUnitOfWork.Users.FindByNameAsync(request.NewUserName);

                    if (newUserName != null && request.NewUserName != user.UserName) return new BadRequestObjectResult(new { errorMessage = "UserName ya existe" });

                    user.UserName = request.NewUserName;
                }

                if (!string.IsNullOrEmpty(request.NewPassword)) user.PasswordHash = _passwordHasher.HashPassword(user, request.NewPassword);

                if (!string.IsNullOrEmpty(request.Logo)) user.Logo = request.Logo;

                var updateResult = await _virtualLibraryUnitOfWork.Users.UpdateAsync(user);

                if (!updateResult.Succeeded) return new BadRequestObjectResult(new { errorMessage = "Usuario no actualizado" });

                var result = _mapper.Map<UpdateUserDto>(user);

                return new OkObjectResult(result);
            }
        }
    }
}
