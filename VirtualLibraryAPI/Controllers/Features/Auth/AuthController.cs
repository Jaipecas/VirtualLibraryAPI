using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }
    }
}
