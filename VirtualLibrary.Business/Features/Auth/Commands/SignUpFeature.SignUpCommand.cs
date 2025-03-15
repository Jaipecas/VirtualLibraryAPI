using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignUpFeature
    {
        public partial class SignUpCommand : IRequest<IActionResult>
        {
            public required string Id { get; set; }
            public required string UserName { get; set; }
            public required string Email { get; set; }
            public required string Password { get; set; }
        }
    }

}
