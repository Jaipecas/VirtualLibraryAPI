
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class UpdateUserFeature
    {
        public class UpdateUserCommand : IRequest<Result<UpdateUserDto>>
        {
            public required string CurrentUserName { get; set; }
            public required string CurrentEmail { get; set; }
            public string? NewUserName { get; set; }
            public string? NewEmail { get; set; }
            public string? NewPassword { get; set; }
            public string? Logo { get; set; }
        }
    }
}
