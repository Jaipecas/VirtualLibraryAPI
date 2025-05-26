using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static VirtualLibrary.Application.Features.NotificationFeatures.AddNotificationFeature;
using static VirtualLibrary.Application.Features.NotificationFeatures.DeleteNotificationFeature;
using static VirtualLibrary.Application.Features.NotificationFeatures.Queries.GetNotificationsFeature;

namespace VirtualLibraryAPI.Controllers.Features.NotificationFeatures
{
    [Authorize]
    [Route("api/notification")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddNotification(AddNotificationCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(result.Value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNotification([FromQuery] DeleteNotificationCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications([FromQuery] GetNoticationsQuery query)
        {
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(result.Value);
        }
    }
}
