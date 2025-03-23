using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static VirtualLibrary.Application.Features.NotificationFeatures.AddNotificationFeature;

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
            return await _mediator.Send(command);
        }
    }
}
