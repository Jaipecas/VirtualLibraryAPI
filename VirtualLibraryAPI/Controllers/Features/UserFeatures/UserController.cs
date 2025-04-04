using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static VirtualLibrary.Application.Features.UserFeatures.Command.UpdateUserFriendsFeature;
using static VirtualLibrary.Application.Features.UserFeatures.Queries.GetUserDataByIdFeature;

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
        public async Task<IActionResult> GetUserById([FromQuery] GetUserDataByIdQuery request)
        {
            return await _mediator.Send(request);
        }
    }
}
