using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.AddStudyRoomFeature;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.DeleteStudyRoomFeature;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.UpdateRoomTimerFeature;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.UpdateStudyRoomFeature;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Queries.GetInvitedStudyRoomsFeature;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Queries.GetStudyRoomByIdFeature;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Queries.GetStudyRoomsByOwnerFeature;


namespace VirtualLibraryAPI.Controllers.Features.StudyRoomFeatures
{
    [Authorize]
    [Route("api/studyroom")]
    [ApiController]
    public class StudyRoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudyRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> AddStudyRoom(AddStudyRoomCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(result.Value);
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteStudyRoom([FromQuery] DeleteStudyRoomCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateStudyRoom(UpdateStudyRoomCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("getStudyRoomsByOwner")]
        public async Task<IActionResult> GetStudyRoomsByOwner([FromQuery] GetStudyRoomsByOwnerQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("getInvitedStudyRooms")]
        public async Task<IActionResult> GetStudyRoomsByUser([FromQuery] GetInvitedStudyRoomsQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("getStudyRoomById")]
        public async Task<IActionResult> GetStudyRoomById([FromQuery] GetStudyRoomByIdQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut("updateRoomTimer")]
        public async Task<IActionResult> UpdateRoomTimer(UpdateRoomTimerCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
