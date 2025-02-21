using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Persistence;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class UpdateUserFeature
    {
        public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, IActionResult>
        {
            private readonly IVirtualLibraryUnitOfWork _virtualLibraryUnitOfWork;
            private readonly IMapper _mapper;

            public UpdateUserHandler(IVirtualLibraryUnitOfWork virtualLibraryUnitOfWork, IMapper mapper)
            {
                _virtualLibraryUnitOfWork = virtualLibraryUnitOfWork;
                _mapper = mapper;
            }

            public async Task<IActionResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _virtualLibraryUnitOfWork.Users.FindByEmailAsync(request.CurrentEmail);

                if (user == null) return new UnauthorizedObjectResult(new { errorMessage = "Invalid user" });

                if (!string.IsNullOrEmpty(request.NewEmail))
                {
                    var newUser = await _virtualLibraryUnitOfWork.Users.FindByEmailAsync(request.NewEmail);

                    if (newUser != null) return new BadRequestObjectResult(new { errorMessage = "Email ya existe" });

                    user.Email = request.NewEmail;
                }

                if (!string.IsNullOrEmpty(request.NewUserName))
                {
                    var newUserName = await _virtualLibraryUnitOfWork.Users.FindByNameAsync(request.NewUserName);

                    if (newUserName != null) return new BadRequestObjectResult(new { errorMessage = "UserName ya existe" });

                    user.UserName = request.NewUserName;
                }

                if (!string.IsNullOrEmpty(request.Password) && !string.IsNullOrEmpty(request.ConfirmPassword))
                {
                    var changePassword = await _virtualLibraryUnitOfWork.Users.ChangePasswordAsync(user, request.Password, request.ConfirmPassword);

                    if (!changePassword.Succeeded) return new BadRequestObjectResult(new { errorMessage = "Contraseña no actualizada" });
                }

                var updateResult = await _virtualLibraryUnitOfWork.Users.UpdateAsync(user);

                if (!updateResult.Succeeded) return new BadRequestObjectResult(new { errorMessage = "Usuario no actualizado" });

                return new OkObjectResult(updateResult);
            }
        }
    }
}
