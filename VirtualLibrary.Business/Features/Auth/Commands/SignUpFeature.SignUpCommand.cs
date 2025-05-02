using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignUpFeature
    {
        public partial class SignUpCommand : IRequest<Result<SignUpDto>>
        {
            public required string UserName { get; set; }
            public required string Email { get; set; }
            public required string Password { get; set; }
        }
    }

}
