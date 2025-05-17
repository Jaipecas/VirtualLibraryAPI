using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static VirtualLibrary.Application.Features.UserFriendFeatures.DeleteFriendFeature;

namespace VirtualLibraryAPI.Controllers.Features.UserFriendFeature
{
    [Authorize]
    [Route("api/userfriend")]
    [ApiController]
    public class UserFriendController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserFriendController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserFriend([FromQuery] DeleteFriendCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(result.Value);
        }
    }
}
