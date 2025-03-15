using MediatR;
using Microsoft.AspNetCore.Mvc;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.AddStudyRoomFeature;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Commands.DeleteStudyRoomFeature;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.Queries.GetStudyRoomsByOwnerFeature;

namespace VirtualLibraryAPI.Controllers.Features.StudyRoomFeatures
{
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
            return await _mediator.Send(command);
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteStudyRoom([FromQuery] DeleteStudyRoomCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("GetStudyRoomsByOwner")]
        public async Task<IActionResult> GetStudyRoomsByOwner([FromQuery] GetStudyRoomsByOwnerQuery request)
        {
            return await _mediator.Send(request);
        }
    }
}
