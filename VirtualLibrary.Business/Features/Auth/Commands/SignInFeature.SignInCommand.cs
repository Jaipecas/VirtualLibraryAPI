using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class SignInFeature
    {
        public class SignInCommand : IRequest<Result<SignInDto>>
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
        }
    }
}
