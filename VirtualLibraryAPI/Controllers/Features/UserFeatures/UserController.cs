using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static VirtualLibrary.Application.Features.UserFeatures.Queries.GetUserDataByIdFeature;

namespace VirtualLibraryAPI.Controllers.Features.UserFeatures
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetUserById([FromQuery] GetUserDataByIdQuery request)
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(new { result.Errors });

            return Ok(result.Value);
        }
    }
}
