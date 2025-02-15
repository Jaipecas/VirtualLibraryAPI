using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignInFeature
    {
        public class SignInCommand : IRequest<IActionResult>
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
        }
    }
}
