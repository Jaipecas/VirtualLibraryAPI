using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static VirtualLibrary.Application.Features.CardFeatures.Commands.AddCardFeature;
using static VirtualLibrary.Application.Features.CardFeatures.Commands.DeleteCardFeature;
using static VirtualLibrary.Application.Features.CardFeatures.Commands.UpdateCardFeature;

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

            return Ok(result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCard(UpdateCardCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(result.Value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCard([FromQuery] DeleteCardCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(result.Value);
        }
    }
}
