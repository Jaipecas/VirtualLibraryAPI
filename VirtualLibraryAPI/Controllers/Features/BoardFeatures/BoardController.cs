using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static VirtualLibrary.Application.Features.BoardFeatures.AddBoardFeature;
using static VirtualLibrary.Application.Features.BoardFeatures.Commands.DeleteBoardFeature;
using static VirtualLibrary.Application.Features.BoardFeatures.Commands.UpdateBoardFeature;
using static VirtualLibrary.Application.Features.BoardFeatures.Queries.GetAllBoardsFeature;
using static VirtualLibrary.Application.Features.BoardFeatures.Queries.GetBoardByIdFeature;

namespace VirtualLibraryAPI.Controllers.Features.BoardFeatures
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

            return Ok(result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBoard(UpdateBoardCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(result.Value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBoard([FromQuery] DeleteBoardCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBoard([FromQuery] GetAllBoardsQuery query)
        {
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoardById(int id)
        {
            var result = await _mediator.Send(new GetBoardByIdQuery { Id = id });

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(result.Value);
        }
    }
}
