using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Domain.Common;
using static VirtualLibrary.Application.Features.BoardFeatures.AddBoardFeature;
using static VirtualLibrary.Application.Features.NotificationFeatures.AddNotificationFeature;
using static VirtualLibrary.Application.Features.NotificationFeatures.DeleteNotificationFeature;
using static VirtualLibrary.Application.Features.NotificationFeatures.Queries.GetNotificationsFeature;

namespace VirtualLibraryAPI.Controllers.Features.NotificationFeatures
{
    [Authorize]
    [Route("api/board")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BoardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddBoard(AddBoardCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(new { Board = result.Value });
        }
    }
}
