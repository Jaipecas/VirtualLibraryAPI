using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static VirtualLibrary.Application.Features.StudyRoomUserFeatures.Commands.UpdateStudyRoomUserFeature;
using static VirtualLibrary.Application.Features.StudyRoomUserFeatures.Queries.GetRoomUsersFeature;


namespace VirtualLibraryAPI.Controllers.Features.StudyRoomUserFeatures
{
    [Authorize]
    [Route("api/studyroomuser")]
    [ApiController]
    public class StudyRoomUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudyRoomUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateStudyRoomUser(UpdateStudyRoomUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(result.Value);
        }
        [HttpGet()]
        public async Task<IActionResult> GetRoomUsers([FromQuery] GetRoomUsersQuery request)
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(result.Value);
        }
    }
}
