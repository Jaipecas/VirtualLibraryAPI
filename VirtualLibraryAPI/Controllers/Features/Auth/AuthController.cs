using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Features.Auth.Commands;

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
    }
}
