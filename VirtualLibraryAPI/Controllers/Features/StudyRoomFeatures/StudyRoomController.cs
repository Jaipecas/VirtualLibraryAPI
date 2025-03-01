using MediatR;
using Microsoft.AspNetCore.Mvc;
using static VirtualLibrary.Application.Features.StudyRoomFeatures.AddStudyRoomFeature;

namespace VirtualLibraryAPI.Controllers.Features.StudyRoomFeatures
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyRoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudyRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddStudyRoom")]
        public async Task<IActionResult> AddStudyRoom(AddStudyRoomCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
