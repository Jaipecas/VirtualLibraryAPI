using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static VirtualLibrary.Application.Features.UserFeatures.Queries.GetUserByNameFeature;

namespace VirtualLibraryAPI.Controllers.Features.UserFeatures
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetUserByName([FromQuery] GetUserByNameQuery request)
        {
            return await _mediator.Send(request);
        }
    }
}
