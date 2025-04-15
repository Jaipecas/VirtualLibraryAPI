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
    public class StudyRoomUserController
    {
        private readonly IMediator _mediator;

        public StudyRoomUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateStudyRoomUser(UpdateStudyRoomUserCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet()]
        public async Task<IActionResult> GetRoomUsers([FromQuery] GetRoomUsersQuery request)
        {
            return await _mediator.Send(request);
        }
    }
}
