using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static VirtualLibrary.Application.Features.CardListFeatures.Command.AddCardListFeature;


namespace VirtualLibraryAPI.Controllers.Features.CardListFeature
{
    [Authorize]
    [Route("api/cardList")]
    [ApiController]
    public class CardListController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CardListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCardList(AddCardListCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(new { Board = result.Value });
        }
    }
}
