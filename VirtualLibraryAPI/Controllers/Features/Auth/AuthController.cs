using MediatR;
using Microsoft.AspNetCore.Mvc;
using static VirtualLibrary.Application.Features.Auth.Commands.LogoutFeature;
using static VirtualLibrary.Application.Features.Auth.Commands.SignInFeature;
using static VirtualLibrary.Application.Features.Auth.Commands.SignUpFeature;
using static VirtualLibrary.Application.Features.Auth.Commands.UpdateUserFeature;

namespace VirtualLibraryAPI.Controllers.Features.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp(SignUpCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn(SignInCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("updateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            return await _mediator.Send(command);            
        }
    }
}
