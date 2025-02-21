
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class UpdateUserFeature
    {
        public class UpdateUserCommand : IRequest<IActionResult>
        {
            public required string CurrentUserName { get; set; }
            public required string CurrentEmail { get; set; }
            public string? NewUserName { get; set; }
            public string? NewEmail { get; set; }
            public string? Password { get; set; }
            public string? ConfirmPassword { get; set; }
        }
    }
}
