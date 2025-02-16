using MediatR;
using Microsoft.AspNetCore.Mvc;
using static VirtualLibrary.Application.Features.Auth.Commands.LogoutFeature;
using static VirtualLibrary.Application.Features.Auth.Commands.SignInFeature;
using static VirtualLibrary.Application.Features.Auth.Commands.SignUpFeature;

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
            var result = await _mediator.Send(command);

            return result;
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn(SignInCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }
    }
}
