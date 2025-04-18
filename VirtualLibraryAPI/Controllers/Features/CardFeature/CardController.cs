using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static VirtualLibrary.Application.Features.CardFeatures.Commands.AddCardFeature;

namespace VirtualLibraryAPI.Controllers.Features.CardFeature
{
    [Authorize]
    [Route("api/cards")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCard(AddCardCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(new { Board = result.Value });
        }
    }
}
